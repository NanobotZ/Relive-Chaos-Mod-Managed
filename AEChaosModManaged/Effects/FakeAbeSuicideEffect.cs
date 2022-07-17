namespace AEChaosModManaged.Effects
{
    public class FakeAbeSuicideEffect : BaseFakeEffect
    {
        public override string Name => "Fake Abe Suicide";
        public override string FakeName => "Abe Suicide";

        public override EffectType Type => EffectType.FakeAbeSuicide;

        internal override bool OneTime => true;
    }
}
