using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Text;

namespace ChaiTea
{
    public class ShapeSphere : GenericObject
    {

        public ShapeSphere(double radius) : base(ShapeSphere_Create(radius))
        {

        }

        [DllImport("ChaiTeaLib", EntryPoint = "ShapeSphere_Create")]
        internal static extern IntPtr ShapeSphere_Create(double radius);
    }
}
