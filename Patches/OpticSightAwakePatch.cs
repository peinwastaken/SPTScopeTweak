using EFT.CameraControl;
using HarmonyLib;
using SPT.Reflection.Patching;
using SPTScopeTweaks.Data;
using SPTScopeTweaks.Helpers;
using System.Reflection;
using UnityEngine;

namespace SPTScopeTweaks.Patches
{
    public class OpticSightAwakePatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(OpticSight), nameof(OpticSight.Awake));
        }

        [PatchPostfix]
        private static void PatchPostfix(OpticSight __instance)
        {
            bool scopeExists = ScopeMaterialData.OpticMaterialData.ContainsKey(__instance);

            Renderer opticRenderer = __instance.LensRenderer;
            Material opticMaterial = opticRenderer.material;

            Vector4 _scales = opticMaterial.GetVector(ScopeMaterialData.ScalesKeyword);

            if (!scopeExists)
            {
                ScopeMaterialData scopeMaterialData = new ScopeMaterialData() { _Scales = _scales };
                ScopeMaterialData.OpticMaterialData.Add(__instance, scopeMaterialData);
            }

            ScopeHelper.UpdateScopeEyeRelief(__instance, Plugin.EyeReliefMultiplier.Value);
        }
    }
}
