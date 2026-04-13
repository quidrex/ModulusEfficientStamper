using Data.FactoryFloor.Behaviours;
using HarmonyLib;

namespace EfficientStamper
{
    [HarmonyPatch(typeof(StamperBehaviour), "TryStampShape")]
    internal static class StamperBehaviourPatchTryStampShape
    {
        private static bool Prefix(StamperBehaviour __instance, bool ____isConfigured, ref bool ____hasStampShape0, ref bool ____hasStampShape1)
        {
            if (!____isConfigured)
            {
                __instance.EndActivity();
                return false;
            }

            var additionalData = __instance.GetAdditionalData();
            ref var extraStampShape = ref additionalData._extraStampShape;

            switch (extraStampShape, ____hasStampShape0, ____hasStampShape1)
            {
                case (ExtraStampShape.Has0, false, true):
                    extraStampShape = ExtraStampShape.None;
                    ____hasStampShape0 = true;
                    break;
                case (ExtraStampShape.Has1, true, false):
                    extraStampShape = ExtraStampShape.None;
                    ____hasStampShape1 = true;
                    break;
                case (ExtraStampShape.None, true, false):
                    extraStampShape = ExtraStampShape.Has0;
                    ____hasStampShape0 = false;
                    break;
                case (ExtraStampShape.None, false, true):
                    extraStampShape = ExtraStampShape.Has1;
                    ____hasStampShape1 = false;
                    break;
            }

            return true;
        }
    }
}
