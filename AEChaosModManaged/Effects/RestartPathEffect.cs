namespace AEChaosModManaged.Effects
{
    public class RestartPathEffect : BaseEffect
    {
        public override string Name => "Restart Path";

        public override EffectType Type => EffectType.RestartPath;

        internal override bool OneTime => true;
    }
}
