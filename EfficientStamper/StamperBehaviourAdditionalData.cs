using System.Runtime.CompilerServices;
using Data.FactoryFloor.Behaviours;

namespace EfficientStamper
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
