namespace AEChaosModManaged.Effects
{
    public class SpawnSlogsEffect : BaseEffect
    {
        public override string Name => "Spawn Slogs";

        public override EffectType Type => EffectType.SpawnSlogs;

        internal override bool OneTime => true;
    }
}
