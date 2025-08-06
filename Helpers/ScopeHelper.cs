using EFT.CameraControl;
using SPTScopeTweaks.Data;
using UnityEngine;

namespace SPTScopeTweaks.Helpers
{
    public static class ScopeHelper
    {
        public static void UpdateScopeEyeRelief(OpticSight opticSight, float multiplier)
        {
            ScopeMaterialData scopeMaterialData = ScopeMaterialData.OpticMaterialData[opticSight];
            if (scopeMaterialData == null) return;

            Renderer opticRenderer = opticSight.LensRenderer;
            Material opticMaterial = opticRenderer.material;

            Vector4 _scales = opticMaterial.GetVector(ScopeMaterialData.ScalesKeyword);
            float newScale = scopeMaterialData._Scales.y * multiplier;
            _scales.y = newScale;

            opticMaterial.SetVector(ScopeMaterialData.ScalesKeyword, _scales);
        } 
    }
}
