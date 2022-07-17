namespace AEChaosModManaged.Effects
{
    public class GiveRocksEffect : BaseEffect
    {
        public override string Name => "Give Rocks";
        public override EffectType Type => EffectType.GiveRocks;
        internal override bool OneTime => true;
    }
}
