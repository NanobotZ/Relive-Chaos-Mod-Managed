namespace AEChaosModManaged.Effects
{
    public class GiveInvisibilityRingEffect : BaseEffect
    {
        public override string Name => "Give Invisibility Ring";

        public override EffectType Type => EffectType.GiveInvisibilityRing;

        internal override bool OneTime => true;
    }
}
