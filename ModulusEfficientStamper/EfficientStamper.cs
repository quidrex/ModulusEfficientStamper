using System.Runtime.CompilerServices;
using Data.FactoryFloor.Behaviours;
using HarmonyLib;
using MelonLoader;
using ModulusEfficientStamper;

[assembly: MelonInfo(typeof(MyMod), "Efficient Stamper", "0.1.0", "Quidrex")]
[assembly: MelonGame("Happy Volcano", "Modulus")]

namespace ModulusEfficientStamper
{
    public class MyMod : MelonMod
    {
    }
}

public class StamperBehaviourAdditionalData
{
    public int extraStampShape = -1;
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

[HarmonyPatch(typeof(StamperBehaviour), "TryStampShape")]
internal static class StamperBehaviourPatchTryStampShape
{
    private static bool Prefix(StamperBehaviour __instance, bool ____isConfigured, ref bool ____hasStampShape0, ref bool ____hasStampShape1)
    {
        var additionalData = __instance.GetAdditionalData();

        if (!____isConfigured)
        {
            __instance.EndActivity();
            return false;
        }

        if (____hasStampShape0 && !____hasStampShape1 && additionalData.extraStampShape == -1)
        {
            ____hasStampShape0 = false;
            additionalData.extraStampShape = 0;
        }

        if (!____hasStampShape0 && ____hasStampShape1 && additionalData.extraStampShape == -1)
        {
            ____hasStampShape1 = false;
            additionalData.extraStampShape = 1;
        }

        return true;
    }
}


[HarmonyPatch(typeof(StamperBehaviour), "OnOutput")]
internal static class StamperBehaviourPatchOnOutput
{
    private static void Postfix(StamperBehaviour __instance, ref bool ____hasStampShape0, ref bool ____hasStampShape1)
    {
        var additionalData = __instance.GetAdditionalData();

        if (!____hasStampShape0 && additionalData.extraStampShape == 0)
        {
            ____hasStampShape0 = true;
            additionalData.extraStampShape = -1;
        }

        if (!____hasStampShape1 && additionalData.extraStampShape == 1)
        {
            ____hasStampShape1 = true;
            additionalData.extraStampShape = -1;
        }
    }
}
