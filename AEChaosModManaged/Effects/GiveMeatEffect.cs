namespace AEChaosModManaged.Effects
{
    public class GiveMeatEffect : BaseEffect
    {
        public override string Name => "Give Meat";
        public override EffectType Type => EffectType.GiveMeat;
        internal override bool OneTime => true;
    }
}
