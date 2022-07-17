namespace AEChaosModManaged.Effects
{
    public class AbeInvisibleEffect : BaseEffect
    {
        public override string Name => "Abe Invisible";

        public override EffectType Type => EffectType.AbeInvisible;

        internal override bool OneTime => true;
    }
}
