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
    public int _extraStampShape = -1;
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
