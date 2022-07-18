namespace AEChaosModManaged.Effects
{
    public class GiveRedRingEffect : BaseEffect
    {
        public override string Name => "Give Red Ring";

        public override EffectType Type => EffectType.GiveRedRing;

        internal override bool OneTime => true;
    }
}
