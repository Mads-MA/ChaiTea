using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Text;

namespace ChaiTea
{
    public class ShapeCylinder : GenericObject
    {
        //Unity does not allow scaling of top and bottom independently
        public ShapeCylinder(double radius, double height) 
            : base(ShapeCylinder_Create(radius, radius, height))
        {
        }

        [DllImport("ChaiTeaLib", EntryPoint = "ShapeCylinder_Create")]
        internal static extern IntPtr ShapeCylinder_Create(double baseRadius, double topRadius, double height);
    }
}
