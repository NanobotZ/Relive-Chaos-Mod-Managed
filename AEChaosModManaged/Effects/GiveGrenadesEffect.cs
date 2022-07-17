namespace AEChaosModManaged.Effects
{
    public class GiveGrenadesEffect : BaseEffect
    {
        public override string Name => "Give Grenades";
        public override EffectType Type => EffectType.GiveGrenades;
        internal override bool OneTime => true;
    }
}
