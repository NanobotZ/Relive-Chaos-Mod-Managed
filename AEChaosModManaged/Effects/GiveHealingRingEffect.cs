namespace AEChaosModManaged.Effects
{
    public class GiveHealingRingEffect : BaseEffect
    {
        public override string Name => "Give Healing Ring";

        public override EffectType Type => EffectType.GiveHealingRing;

        internal override bool OneTime => true;
    }
}
