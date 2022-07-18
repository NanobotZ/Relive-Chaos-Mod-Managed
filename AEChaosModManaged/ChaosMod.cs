using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AEChaosModManaged
{
    public class ChaosMod : IDisposable
    {
        public static ChaosMod Instance { get; private set; }

        internal ChaosConfig Config { get; private set; }

        public float SpeedModifier { get; set; }

        public string ErrorInfo { get; set; }


        internal List<BaseEffect> AllEffects { get; private set; }

        internal int ChatQueueCount { get; private set; }
        internal Queue<string> ChatQueue { get; private set; }

        internal DateTime effectStartTime;
        internal TimeSpan effectDuration;
        internal BaseEffect activeEffect;

        private BaseEffect randomEffect;
        private VotingManager<BaseEffect> votingManager;
        private OverlayServer overlayServer;

        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        private Task updateTask;

        private IRCClient ircClient;

        private static bool testMode = false;

        public ChaosMod()
        {
            SpeedModifier = 1.0f;
            AllEffects = new List<BaseEffect>();
        }

        private void Init()
        {
            Config = new ChaosConfig();
            Config.Read();

            if (testMode)
            {
                Config.GlobalEffectDurationSeconds = 6;
            }

            ErrorInfo = null;
            effectStartTime = DateTime.Now;
            effectDuration = TimeSpan.FromSeconds(Config.GlobalEffectDurationSeconds);
            activeEffect = null;

            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;

            PopulateEffects();

            if (Config.IsVotingEnabled)
            {
                ChatQueueCount = Config.ShowVotingAs == ChaosConfig.ShowVotingType.InGame ? 20 - Config.MaxOptionsPerVoting - 1 : 20;
                if (ChatQueueCount > 0)
                    ChatQueue = new Queue<string>(ChatQueueCount);

                votingManager = new VotingManager<BaseEffect>(Config.MaxOptionsPerVoting);
                votingManager.Reset(GetRandomEffects(Config.MaxOptionsPerVoting));

                ircClient = new IRCClient(Config.TwitchUsername);
                ircClient.MessageReceived += IrcClient_MessageReceived;
                ircClient.Start(cancellationToken);

                if (Config.ShowVotingAs == ChaosConfig.ShowVotingType.Overlay)
                {
                    overlayServer = new OverlayServer(votingManager);
                    overlayServer.Start(cancellationToken);
                }
            }

            updateTask = new Task(() => Update());
            updateTask.Start();
        }

        private void IrcClient_MessageReceived(object sender, IRCClient.MessageReceivedEventArgs e)
        {
            votingManager.HandleVote(e.Username, e.Message);

            if (Config.ShowVotingAs == ChaosConfig.ShowVotingType.Overlay)
            {
                overlayServer.UpdateVotes();
            }

            if (activeEffect?.Type == EffectType.InGameChat)
            {
                var chatMsg = $"{e.Username}: {e.Message}";

                foreach (var split in chatMsg.SplitEveryNCharactersWithDelimeter(78))
                {
                    ChatQueue.Enqueue(split);
                }

                while (ChatQueue.Count >= ChatQueueCount)
                    ChatQueue.Dequeue();
            }
        }

        private IEnumerable<BaseEffect> GetRandomEffects(int count)
        {
            if (testMode)
            {
                int index = activeEffect != null ? AllEffects.FindIndex(x => x == activeEffect) : 0;
                index = index == AllEffects.Count - 1 ? 0 : index + 1;
                return new List<BaseEffect>() { AllEffects[index] };
            }

            var rand = new Random();
            var randEffects = AllEffects.OrderByDescending(x => x.Weight * rand.Next()).Take(count).OrderBy(x => x.Name).ToList();
            if (Config.AllowRandomVoteOption && randEffects.Count > 1)
                randEffects.Add(randomEffect);

            return randEffects;
        }

        private void Update()
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    if (Config.IsVotingEnabled)
                        ircClient.Update();

                    if (DateTime.Now >= effectStartTime + effectDuration)
                    {
                        if (Config.IsVotingEnabled)
                        {
                            var votingResult = votingManager.GetResultAndReset(GetRandomEffects(Config.MaxOptionsPerVoting));
                            NewEffect(votingResult);

                            if (Config.ShowVotingAs == ChaosConfig.ShowVotingType.Overlay)
                            {
                                overlayServer.UpdateVotes();
                            }
                        }
                        else
                        {
                            NewEffect(GetRandomEffects(1).FirstOrDefault());
                        }
                    }
                    else
                        activeEffect?.Update();

                    try
                    {
                        Task.Delay(50).Wait(cancellationToken);
                    }
                    catch (OperationCanceledException)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                ErrorInfo = ex.Message;
            }
        }

        internal void NewEffect(BaseEffect effect)
        {
            if (activeEffect != null)
                activeEffect.Stop();

            TimeSpan duration;
            if (effect.DurationModifier <= 0.0f)
                duration = TimeSpan.FromSeconds(Config.GlobalEffectDurationSeconds);
            else
                duration = TimeSpan.FromSeconds(Config.GlobalEffectDurationSeconds * effect.DurationModifier);

            effectStartTime = DateTime.Now;
            effectDuration = duration;
            activeEffect = effect;
            effect.Start();
        }

        private void PopulateEffects()
        {
            AllEffects.Clear();

            var effectType = typeof(BaseEffect);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.IsClass && !p.IsAbstract && p.IsSubclassOf(effectType));

            foreach (var type in types)
            {
                var instance = (BaseEffect)Activator.CreateInstance(type);

                if (Config.EffectSettings.ContainsKey(instance.Name))
                    instance.SetData(Config.EffectSettings[instance.Name].Weight, Config.EffectSettings[instance.Name].DurationModifier);

                if (instance.Type == EffectType.Random)
                    randomEffect = instance;
                else
                {
                    if (instance.Weight <= 0.0f)
                        continue;

                    if (instance.AppearCondition == EffectAppearCondition.VotingEnabled && !Config.IsVotingEnabled)
                        continue;

                    AllEffects.Add(instance);
                }
            }
        }

        public void Dispose()
        {
            Instance = null;

            cancellationTokenSource.Cancel();
            updateTask.Wait();
            if (Config.IsVotingEnabled)
                ircClient.Wait();
            if (Config.IsVotingEnabled && Config.ShowVotingAs == ChaosConfig.ShowVotingType.Overlay)
                overlayServer.Wait();

            cancellationTokenSource.Dispose();
            updateTask.Dispose();
            if (Config.IsVotingEnabled)
                ircClient.Dispose();
            if (Config.IsVotingEnabled && Config.ShowVotingAs == ChaosConfig.ShowVotingType.Overlay)
                overlayServer.Dispose();
        }


#pragma warning disable IDE1006 // Naming Styles
        [DllExport]
        public static void _init()
        {
            if (Instance == null)
            {
                Instance = new ChaosMod();
                Instance.Init();
            }
        }

        [DllExport]
        public static int _getEffectDuration() => (int)(Instance.effectStartTime + Instance.effectDuration - DateTime.Now).TotalSeconds;

        [DllExport]
        public static int _getFullEffectDuration() => (int)Instance.effectDuration.TotalSeconds;

        [DllExport]
        public static uint _getActiveEffect()
        {
            var effect = Instance.activeEffect?.Type ?? EffectType.None;
            var oneTime = (Instance.activeEffect?.OneTime ?? false) ? (uint)1 : 0;

            uint result = (ushort)effect;
            result |= oneTime << 24;

            return result;
        }

        [DllExport]
        public static float _getSpeedModifier() => Instance?.SpeedModifier ?? 1.0f;

        [DllExport]
        public static void _getInfo(IntPtr ptr, int bufferLen)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Active effect: " +
                (Instance.activeEffect != null ? Instance.activeEffect.ToString() : "None") +
                (" - " + (int)(Instance.effectStartTime + Instance.effectDuration - DateTime.Now).TotalSeconds).ToString() + "s");

            if (Instance.Config.IsVotingEnabled && Instance.Config.ShowVotingAs == ChaosConfig.ShowVotingType.InGame)
            {
                if (sb.Length > 0)
                    sb.AppendLine(" ");

                var option = 0;
                sb.AppendLine("Voting:");
                foreach (var (item, votes) in Instance.votingManager.Options)
                    sb.AppendLine($"{++option}. {item}: {votes}");
            }

            if (!string.IsNullOrEmpty(Instance.ErrorInfo))
            {
                if (sb.Length > 0)
                    sb.AppendLine(" ");

                //sb.AppendLine("Error: " + Instance.errorInfo);
                sb.AppendLine(Instance.ErrorInfo);
            }

            if (Instance.Config.IsVotingEnabled && Instance.ChatQueueCount > 0 && Instance.ChatQueue.Count > 0)
            {
                if (sb.Length > 0)
                    sb.AppendLine(" ");

                foreach (var chatMsg in Instance.ChatQueue)
                    sb.AppendLine(chatMsg);
            }

            var result = sb.Length + 1 > bufferLen ? sb.ToString().Substring(0, bufferLen) : sb.ToString();
            result += '\0';
            Marshal.Copy(Encoding.ASCII.GetBytes(result), 0, ptr, result.Length);
        }

        [DllExport]
        public static void _skipCurrentEffect()
        {
            Instance.effectDuration = TimeSpan.FromSeconds((Instance.effectStartTime + Instance.effectDuration - DateTime.Now).TotalSeconds + 2); // leave at least two seconds for the game to clean current effect
        }

        [DllExport]
        public static void _close()
        {
            if (Instance != null)
            {
                Instance.Dispose();
                Instance = null;
            }
        }
#pragma warning restore IDE1006 // Naming Styles

        public enum ShowVotingType : ushort
        {
            None,
            InGame,
            Overlay
        }
    }
}
