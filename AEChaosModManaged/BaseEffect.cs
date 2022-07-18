using System;

namespace AEChaosModManaged
{
    public abstract class BaseEffect : IEquatable<BaseEffect>
    {
        public abstract string Name { get; }
        public abstract EffectType Type { get; }
        public virtual float DurationModifier { get; private set; } = 1.0f;
        public virtual float Weight { get; private set; } = 1.0f;
        internal virtual bool OneTime { get; } = false;
        internal virtual EffectAppearCondition AppearCondition { get; } = EffectAppearCondition.None;

        internal protected BaseEffect()
        {

        }

        internal virtual void Start() { }
        internal virtual void Update() { }
        internal virtual void Stop() { }

        internal void SetData(float weight, float durationModifier)
        {
            Weight = weight;
            DurationModifier = durationModifier;
        }

        public override string ToString() => Name;

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType() || !object.ReferenceEquals(this, obj))
                return false;

            var other = (BaseEffect)obj;
            return Name == other.Name && Type == other.Type;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Type.GetHashCode();
        }

        public bool Equals(BaseEffect other)
        {
            return Equals((object)other);
        }
    }

    public enum EffectType : ushort
    {
        None,
        Other,
        AbeSuicide,
        RestartPath,
        ThrowBackwards,
        Disco,
        AbeInvisible,
        AllMudsToAbe,
        GiveGrenades,
        SpawnSlig,
        SpawnSligs,
        GiveRocks,
        GiveMeat,
        GiveBones,
        ShrykullGrenades,
        SpawnSlog,
        SpawnSlogs,
        Dinnerbone,
        HorizontalDinnerbone,
        Superhot,
        InGameChat,
        FakeAbeSuicide,
        OnePunchAbe,
        IndestructibleAbe,
        FatAbe,
        BarrelRoll,
        FlipScreenX,
        FlipScreenY,
        BouncyThrowables,
        SpawnUXBs,
        Fade,
        Random = 65535
    }

    internal enum EffectAppearCondition : ushort
    {
        None,
        VotingEnabled
    }
}
