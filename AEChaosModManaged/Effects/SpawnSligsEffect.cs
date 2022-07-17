namespace AEChaosModManaged.Effects
{
    public class SpawnSligsEffect : BaseEffect
    {
        public override string Name => "Spawn Sligs";

        public override EffectType Type => EffectType.SpawnSligs;

        internal override bool OneTime => true;
    }
}
