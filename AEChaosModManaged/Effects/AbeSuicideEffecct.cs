namespace AEChaosModManaged.Effects
{
    public class AbeSuicideEffecct : BaseEffect
    {
        public override string Name => "Abe Suicide";

        public override EffectType Type => EffectType.AbeSuicide;

        internal override bool OneTime => true;
    }
}
