namespace AEChaosModManaged.Effects
{
    public class SpawnSlogEffect : BaseEffect
    {
        public override string Name => "Spawn Slog";

        public override EffectType Type => EffectType.SpawnSlog;

        internal override bool OneTime => true;
    }
}
