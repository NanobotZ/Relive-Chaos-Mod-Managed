using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEChaosModManaged
{
    public abstract class BaseFakeEffect : BaseEffect
    {
        public abstract string FakeName { get; }

#if CHAOSMOD
        public override string ToString()
        {
            if (DateTime.Now < ChaosMod.Instance.effectStartTime + TimeSpan.FromSeconds(5))
                return FakeName;

            return base.ToString();
        }
#endif
    }
}
