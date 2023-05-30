using System;
using System.Runtime.InteropServices;

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
