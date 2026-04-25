using System.Runtime.CompilerServices;
using Data.FactoryFloor.Behaviours;

namespace ModulusEfficientStamper
{
    public enum ExtraStampShape
    {
        None,
        Has0,
        Has1
    }

    public class StamperBehaviourAdditionalData
    {
        public ExtraStampShape _extraStampShape = ExtraStampShape.None;

        public void Reset()
        {
            _extraStampShape = ExtraStampShape.None;
        }
    }

    public static class StamperBehaviourAdditionalDataTable<T> where T : ResourceHolderBehaviour
    {
        private static readonly ConditionalWeakTable<T, StamperBehaviourAdditionalData> Data =
            new ConditionalWeakTable<T, StamperBehaviourAdditionalData>();

        public static StamperBehaviourAdditionalData GetAdditionalData(T stamperBehaviour)
        {
            return Data.GetOrCreateValue(stamperBehaviour);
        }
    }
}
