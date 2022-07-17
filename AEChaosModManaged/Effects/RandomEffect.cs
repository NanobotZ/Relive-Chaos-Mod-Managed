using System;
using System.Linq;

namespace AEChaosModManaged.Effects
{
    public class RandomEffect : BaseEffect
    {
        public override string Name => "Random";

        public override EffectType Type => EffectType.Random;

#if CHAOSMOD
        internal override void Start()
        {
            ChaosMod.Instance.NewEffect(ChaosMod.Instance.AllEffects[new Random().Next(ChaosMod.Instance.AllEffects.Count)]);
        }
#endif
    }
}
