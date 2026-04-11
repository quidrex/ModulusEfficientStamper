using Data.FactoryFloor.Behaviours;
using HarmonyLib;

namespace ModulusEfficientStamper
{
    [HarmonyPatch(typeof(StamperBehaviour), "SetStampConfig")]
    internal static class StamperBehaviourPatchSetStampConfig
    {
        private static bool Prefix(StamperBehaviour __instance)
        {
            __instance.GetAdditionalData().Reset();
            return true;
        }
    }

    [HarmonyPatch(typeof(StamperBehaviour), "ResetStampConfig")]
    internal static class StamperBehaviourPatchResetStampConfig
    {
        private static bool Prefix(StamperBehaviour __instance)
        {
            __instance.GetAdditionalData().Reset();
            return true;
        }
    }
}
