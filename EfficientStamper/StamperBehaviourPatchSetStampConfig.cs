using Data.FactoryFloor.Behaviours;
using HarmonyLib;

namespace ModulusEfficientStamper
{
    internal static class StamperBehaviourPatchSetStampConfig<T> where T : ResourceHolderBehaviour
    {
        internal static bool Prefix(T __instance)
        {
            StamperBehaviourAdditionalDataTable<T>.GetAdditionalData(__instance).Reset();
            return true;
        }
    }

    [HarmonyPatch(typeof(StamperBehaviour), "SetStampConfig")]
    internal static class StamperBehaviourPatchSetStampConfig
    {
        private static bool Prefix(StamperBehaviour __instance)
        {
            return StamperBehaviourPatchSetStampConfig<StamperBehaviour>.Prefix(__instance);
        }
    }

    [HarmonyPatch(typeof(StamperBehaviour), "ResetStampConfig")]
    internal static class StamperBehaviourPatchResetStampConfig
    {
        private static bool Prefix(StamperBehaviour __instance)
        {
            return StamperBehaviourPatchSetStampConfig<StamperBehaviour>.Prefix(__instance);
        }
    }

    [HarmonyPatch(typeof(StamperMK2Behaviour), "SetStampConfig")]
    internal static class StamperBehaviourMK2PatchSetStampConfig
    {
        private static bool Prefix(StamperMK2Behaviour __instance)
        {
            return StamperBehaviourPatchSetStampConfig<StamperMK2Behaviour>.Prefix(__instance);
        }
    }

    [HarmonyPatch(typeof(StamperMK2Behaviour), "ResetStampConfig")]
    internal static class StamperBehaviourMK2PatchResetStampConfig
    {
        private static bool Prefix(StamperMK2Behaviour __instance)
        {
            return StamperBehaviourPatchSetStampConfig<StamperMK2Behaviour>.Prefix(__instance);
        }
    }
}
