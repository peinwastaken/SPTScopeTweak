using EFT.CameraControl;
using System.Collections.Generic;
using UnityEngine;

namespace SPTScopeTweaks.Data
{
    public class ScopeMaterialData
    {
        public static Dictionary<OpticSight, ScopeMaterialData> OpticMaterialData = new Dictionary<OpticSight, ScopeMaterialData>();

        public static string ScalesKeyword = "_Scales";
        public static string ShiftDirectionKeyword = "_ShiftDirection";
        public static string ShiftsKeyword = "_Shifts";

        public Vector4 _Scales;
        public Vector4 _ShiftDirection;
        public Vector4 _Shifts;
    }
}
