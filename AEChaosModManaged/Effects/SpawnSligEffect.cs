namespace AEChaosModManaged.Effects
{
    public class SpawnSligEffect : BaseEffect
    {
        public override string Name => "Spawn Slig";

        public override EffectType Type => EffectType.SpawnSlig;

        internal override bool OneTime => true;
    }
}
