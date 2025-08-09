using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using SPTScopeTweaks.Helpers;
using SPTScopeTweaks.Patches;

namespace SPTScopeTweaks
{
    [BepInPlugin("com.pein.scopetweak", "Eye Relief Tweak", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;

        public static ConfigEntry<float> EyeReliefMultiplier { get; private set; }
        public static ConfigEntry<float> PipScaleFovModifier { get; private set; }
        public static ConfigEntry<float> ScopePictureSizeMultiplier { get; private set; }

        private void Awake()
        {
            Logger = base.Logger;

            new OpticSightPatches().Enable();
            new ScopeZoomHandlerAwakePatch().Enable();

            ScopePictureSizeMultiplier = Config.Bind("General", "ScopePipSize", 1.25f, new ConfigDescription("", new AcceptableValueRange<float>(0.1f, 5f)));
            PipScaleFovModifier = Config.Bind("General", "FovModifier", 1.1334f, new ConfigDescription("", null));
            EyeReliefMultiplier = Config.Bind("General", "Eye Relief Multiplier", 1.4f, new ConfigDescription("Multiplies the eye relief size for all optics.", new AcceptableValueRange<float>(0.1f, 5f)));

            EyeReliefMultiplier.SettingChanged += (sender, args) => ScopeHelper.UpdateAllEyeRelief();
            ScopePictureSizeMultiplier.SettingChanged += (sender, args) => ScopeHelper.UpdateAllEyeRelief();
            PipScaleFovModifier.SettingChanged += (sender, args) => ScopeHelper.UpdateAllEyeRelief();
        }
    }
}
