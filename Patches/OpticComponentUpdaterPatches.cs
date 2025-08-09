using EFT.CameraControl;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;
using UnityEngine;

namespace SPTScopeTweaks.Patches
{
    public class ScopeZoomHandlerAwakePatch : ModulePatch
    {
        private static FieldInfo cameraField;
        private static FieldInfo zoomHandlerField;

        protected override MethodBase GetTargetMethod()
        {
            cameraField = AccessTools.Field(typeof(OpticComponentUpdater), "camera_0");
            zoomHandlerField = AccessTools.Field(typeof(OpticComponentUpdater), "scopeZoomHandler_0");

            return AccessTools.Method(typeof(OpticComponentUpdater), nameof(OpticComponentUpdater.LateUpdate));
        }

        [PatchPostfix]
        private static void PatchPostfix(OpticComponentUpdater __instance)
        {
            Camera opticCamera = (Camera)cameraField.GetValue(__instance);
            ScopeZoomHandler zoomHandler = (ScopeZoomHandler)zoomHandlerField.GetValue(__instance);

            if (zoomHandler == null || opticCamera == null) return;

            opticCamera.fieldOfView = zoomHandler.FiledOfView * Plugin.ScopePictureSizeMultiplier.Value * Plugin.PipScaleFovModifier.Value;
        }
    }
}
