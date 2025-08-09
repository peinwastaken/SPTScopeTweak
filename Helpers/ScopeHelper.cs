using EFT.CameraControl;
using SPTScopeTweaks.Data;
using System.Collections.Generic;
using UnityEngine;

namespace SPTScopeTweaks.Helpers
{
    public static class ScopeHelper
    {
        public static void UpdateScopeEyeRelief(OpticSight opticSight)
        {
            ScopeMaterialData scopeMaterialData = ScopeMaterialData.OpticMaterialData[opticSight];
            if (scopeMaterialData == null) return;

            Renderer opticRenderer = opticSight.LensRenderer;
            Material opticMaterial = opticRenderer.material;

            Vector4 _scales = opticMaterial.GetVector(ScopeMaterialData.ScalesKeyword);
            float newScaleX = scopeMaterialData._Scales.x * Plugin.ScopePictureSizeMultiplier.Value; 
            float newScaleY = scopeMaterialData._Scales.y * Plugin.EyeReliefMultiplier.Value;
            _scales.x = newScaleX;
            _scales.y = newScaleY;

            Plugin.Logger.LogInfo(_scales);

            opticMaterial.SetVector(ScopeMaterialData.ScalesKeyword, _scales);
        }

        public static void UpdateAllEyeRelief()
        {
            foreach (KeyValuePair<OpticSight, ScopeMaterialData> kvp in ScopeMaterialData.OpticMaterialData)
            {
                OpticSight opticSight = kvp.Key;
                ScopeMaterialData scopeMaterialData = kvp.Value;

                if (opticSight != null && scopeMaterialData != null)
                {
                    UpdateScopeEyeRelief(opticSight);
                }
            }
        }
    }
}
