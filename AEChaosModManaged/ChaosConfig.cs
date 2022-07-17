using System;
using System.Collections.Generic;
using System.IO;
using ZeroDep;

namespace AEChaosModManaged
{
    public class ChaosConfig
    {
        private static readonly string configPath = "ChaosModConfig.json";
        private static readonly JsonOptions jsonOptions = new JsonOptions() { };
        public bool IsReadCorrectly { get; private set; }

        public int GlobalEffectDurationSeconds { get; set; } = 30;
        public bool IsVotingEnabled { get; set; } = false;
        public ShowVotingType ShowVotingAs { get; set; } = ShowVotingType.None;
        public bool AllowRandomVoteOption { get; set; } = false;
        public int MaxOptionsPerVoting { get; set; } = 4;
        public string TwitchUsername { get; set; } = null;
        public Dictionary<string, EffectData> EffectSettings { get; set; } = new Dictionary<string, EffectData>();

        public void Read()
        {
            if (!File.Exists(configPath))
                return;

            try
            {
                var json = Json.Deserialize<ChaosConfig>(File.ReadAllText(configPath));
                GlobalEffectDurationSeconds = json.GlobalEffectDurationSeconds;
                IsVotingEnabled = json.IsVotingEnabled;
                ShowVotingAs = json.ShowVotingAs;
                AllowRandomVoteOption = json.AllowRandomVoteOption;
                MaxOptionsPerVoting = json.MaxOptionsPerVoting;
                TwitchUsername = json.TwitchUsername;
                EffectSettings = json.EffectSettings;

                IsReadCorrectly = true;
            }
            catch
            {

            }
        }

        public void Save()
        {
            File.WriteAllText(configPath, Json.Serialize(this));
        }

        public enum ShowVotingType : ushort
        {
            None,
            InGame,
            Overlay
        }

        public class EffectData
        {
            public float Weight { get; set; }
            public float DurationModifier { get; set; }
        }
    }
}
