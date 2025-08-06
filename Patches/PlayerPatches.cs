using EFT;
using HarmonyLib;
using SPT.Reflection.Patching;
using SPTScopeTweaks.Data;
using System.Reflection;

namespace SPTScopeTweaks.Patches
{
    public class OnGameEndedPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(Player), nameof(Player.OnGameSessionEnd));
        }

        [PatchPostfix]
        private static void PatchPostfix()
        {
            ScopeMaterialData.OpticMaterialData.Clear();
        }
    }
}
