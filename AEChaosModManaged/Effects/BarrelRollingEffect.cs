namespace AEChaosModManaged.Effects
{
    public class BarrelRollingEffect : BaseEffect
    {
        public override string Name => "Barrel Roll Screen";

        public override EffectType Type => EffectType.BarrelRoll;

        public override float DurationModifier => 0.5f;
    }
}
