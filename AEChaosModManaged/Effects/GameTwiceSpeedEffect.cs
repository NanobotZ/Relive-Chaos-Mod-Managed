namespace AEChaosModManaged.Effects
{
    public class GameTwiceSpeedEffect : BaseEffect
    {
        public override string Name => "Game Twice Speed";

        public override EffectType Type => EffectType.Other;

#if CHAOSMOD
        private float speedMultiplierBefore;

        internal override void Start()
        {
            speedMultiplierBefore = ChaosMod.Instance.SpeedModifier;
            ChaosMod.Instance.SpeedModifier = speedMultiplierBefore * 0.5f;
        }

        internal override void Stop()
        {
            ChaosMod.Instance.SpeedModifier = speedMultiplierBefore;
        }
#endif
    }
}
