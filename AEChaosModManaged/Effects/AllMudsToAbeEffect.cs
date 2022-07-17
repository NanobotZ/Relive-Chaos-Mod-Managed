namespace AEChaosModManaged.Effects
{
    public class AllMudsToAbeEffect : BaseEffect
    {
        public override string Name => "Teleport All Muds To Abe";

        public override EffectType Type => EffectType.AllMudsToAbe;

        internal override bool OneTime => true;
    }
}
