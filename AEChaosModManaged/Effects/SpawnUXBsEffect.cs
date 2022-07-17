namespace AEChaosModManaged.Effects
{
    public class SpawnUXBsEffect : BaseEffect
    {
        public override string Name => "UXB Hell";

        public override EffectType Type => EffectType.SpawnUXBs;

        internal override bool OneTime => true;
    }
}