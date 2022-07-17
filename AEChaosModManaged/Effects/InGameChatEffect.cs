namespace AEChaosModManaged.Effects
{
    public class InGameChatEffect : BaseEffect
    {
        public override string Name => "In Game Twitch Chat";

        public override EffectType Type => EffectType.InGameChat;

        public override float DurationModifier => 1.5f;

#if CHAOSMOD
        internal override EffectAppearCondition AppearCondition => EffectAppearCondition.VotingEnabled;


        internal override void Stop()
        {
            ChaosMod.Instance.ChatQueue.Clear();
        }
#endif
    }
}
