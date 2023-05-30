using System;
using UnityEngine;
using System.Runtime.InteropServices;

namespace ChaiTea
{
    public class ShapeBox : GenericObject
    {

        public ShapeBox(Vector3 size) : base(ShapeBox_Create(size))
        {
            
        }

        [DllImport("ChaiTeaLib", EntryPoint = "ShapeBox_Create")]
        internal static extern IntPtr ShapeBox_Create(Vec3 size);
    }
}
