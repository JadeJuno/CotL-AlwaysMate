using BepInEx.Configuration;
using System.IO;

namespace AlwaysMate
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [BepInDependency("io.github.xhayper.COTL_API")]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "JadeJuno.cotl.AlwaysMate";
        public const string PluginName = "AlwaysMate";
        public const string PluginVer = "1.0.0";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;

        internal static ConfigEntry<bool> AllowSiblingMating = null;

        private void Awake()
        {
            Log = Logger;
            PluginPath = Path.GetDirectoryName(Info.Location);

            AllowSiblingMating = Config.Bind("Settings", "Allow Inbreeding", true, "Enable/Disable Sibling Followers being able to mate with each other (i.e. Narinder with Leshy)");
        }

        private void OnEnable()
        {
            Harmony.PatchAll();
            LogInfo($"Loaded {PluginName}!");
        }

        private void OnDisable()
        {
            Harmony.UnpatchSelf();
            LogInfo($"Unloaded {PluginName}!");
        }

        [HarmonyPatch(typeof(Interaction_MatingTent), "GetChanceToMate", [typeof(FollowerBrain), typeof(FollowerBrain)])]
        [HarmonyPostfix]
        public static void MatingTent_GetChanceToMate(FollowerBrain f1, FollowerBrain f2, ref float __result)
        {
            LogInfo($"Chance of Mating between {f1.Info.Name} and {f2.Info.Name} is {__result * 100f}%.");
            if (!AllowSiblingMating.Value && FollowerManager.AreSiblings(f1.Info.ID, f2.Info.ID))
            {
                return;
            }
            __result = 1f;
            LogInfo("Changed to 100%");
        }
    }
}