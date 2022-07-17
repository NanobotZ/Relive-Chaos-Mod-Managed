namespace AEChaosModManaged.Effects
{
    public class GameHalfSpeedEffect : BaseEffect
    {
        public override string Name => "Game Half Speed";

        public override EffectType Type => EffectType.Other;

#if CHAOSMOD
        private float speedMultiplierBefore;

        internal override void Start()
        {
            speedMultiplierBefore = ChaosMod.Instance.SpeedModifier;
            ChaosMod.Instance.SpeedModifier = speedMultiplierBefore * 2f;
        }

        internal override void Stop()
        {
            ChaosMod.Instance.SpeedModifier = speedMultiplierBefore;
        }
#endif
    }
}
