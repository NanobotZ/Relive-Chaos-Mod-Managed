using System;

namespace AEChaosModManaged.Effects
{
    public class SineSpeedEffect : BaseEffect
    {
        public override string Name => "Sine Speed";

        public override EffectType Type => EffectType.Other;

#if CHAOSMOD
        private static readonly double radian = Math.PI / 180.0;
        private float speedMultiplierBefore;
        private double radians;

        internal override void Start()
        {
            speedMultiplierBefore = ChaosMod.Instance.SpeedModifier;
        }

        internal override void Update()
        {
            radians += radian * 7.0;
            ChaosMod.Instance.SpeedModifier = (float)(Math.Sin(radians) * 0.8) + 1.2f;
        }

        internal override void Stop()
        {
            ChaosMod.Instance.SpeedModifier = speedMultiplierBefore;
        }
#endif
    }
}
