using Data.FactoryFloor.Behaviours;
using HarmonyLib;

namespace ModulusEfficientStamper
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
            (extraStampShape, ____hasStampShape0, ____hasStampShape1) =
                (extraStampShape, ____hasStampShape0, ____hasStampShape1) switch
                {
                    (0, false, true) => (-1, true, true),
                    (1, true, false) => (-1, true, true),
                    (-1, true, false) => (0, false, false),
                    (-1, false, true) => (1, false, false),
                    var other => other
                };

            return true;
        }
    }
}
