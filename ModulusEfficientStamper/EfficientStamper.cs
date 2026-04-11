using System.Runtime.CompilerServices;
using Data.FactoryFloor.Behaviours;
using MelonLoader;
using ModulusEfficientStamper;

[assembly: MelonInfo(typeof(MyMod), "Efficient Stamper", "0.1.0", "Quidrex")]
[assembly: MelonGame("Happy Volcano", "Modulus")]

namespace ModulusEfficientStamper
{
    public class MyMod : MelonMod
    {
    }

    public class StamperBehaviourAdditionalData
    {
        public int _extraStampShape = -1;

        public void Reset()
        {
            _extraStampShape = -1;
        }
    }

    public static class StamperBehaviourExtension
    {
        private static readonly ConditionalWeakTable<StamperBehaviour, StamperBehaviourAdditionalData> data =
            new ConditionalWeakTable<StamperBehaviour, StamperBehaviourAdditionalData>();

        public static StamperBehaviourAdditionalData GetAdditionalData(this StamperBehaviour stamperBehaviour)
        {
            return data.GetOrCreateValue(stamperBehaviour);
        }
    }
}
