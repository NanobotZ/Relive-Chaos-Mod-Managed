namespace AEChaosModManaged.Effects
{
    public class GiveBonesEffect : BaseEffect
    {
        public override string Name => "Give Bones";
        public override EffectType Type => EffectType.GiveBones;
        internal override bool OneTime => true;
    }
}
