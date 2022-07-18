namespace AEChaosModManaged.Effects
{
    public class GiveShrykullRingEffect : BaseEffect
    {
        public override string Name => "Give Shrykull Ring";

        public override EffectType Type => EffectType.GiveShrykullRing;

        internal override bool OneTime => true;
    }
}
