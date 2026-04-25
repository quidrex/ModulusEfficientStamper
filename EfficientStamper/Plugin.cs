using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using ModulusModLoader;

namespace ModulusEfficientStamper
{
    internal static class PluginInfo
    {
        internal const string Guid = "de.quidrex.modulus.efficient_stamper";
        internal const string Name = "Efficient Stamper";
        internal const string Version = "1.0.0";
    }

    [BepInPlugin(PluginInfo.Guid, PluginInfo.Name, PluginInfo.Version)]
    [BepInDependency(LoaderPluginInfo.Guid)]
    public class Plugin : BaseUnityPlugin
    {
        private Harmony _harmony = null!;
        internal static ManualLogSource Log { get; private set; } = null!;

        private void Awake()
        {
            Log = Logger;
            Log.LogInfo($"{PluginInfo.Name} v{PluginInfo.Version} loaded");

            _harmony = new Harmony(PluginInfo.Guid);
            _harmony.PatchAll(typeof(Plugin).Assembly);
        }

        private void OnDestroy()
        {
            _harmony.UnpatchSelf();
        }
    }
}
