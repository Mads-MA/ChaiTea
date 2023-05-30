using System;
using System.Runtime.InteropServices;

namespace ChaiTea
{
    public class HapticMaterial
    {
        protected IntPtr ptr = IntPtr.Zero;

        public IntPtr Pointer { get => ptr; }


        public HapticMaterial() 
        {
            this.ptr = HapticMaterial_Create();
        }

        public HapticMaterial(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public void SetStiffness(double stiffness)
        {
            HapticMaterial_SetStiffness(ptr, stiffness);
        }

        public void SetDamping(double damping)
        {
            HapticMaterial_SetDamping(ptr, damping);
        }

        public void SetViscosity(double viscosity)
        {
            HapticMaterial_SetViscosity(ptr, viscosity);
        }

        public void SetFriction(double staticFriction, double dynamicFriction)
        {
            HapticMaterial_SetStaticFriction(ptr, staticFriction);
            HapticMaterial_SetDynamicFriction(ptr, dynamicFriction);
        }

        public void SetStickSlip(double maxForce, double stiffness)
        {
            HapticMaterial_SetStickSlipMaxForce(ptr, maxForce);
            HapticMaterial_SetStickSlipStiffness(ptr, stiffness);
        }

        public void SetMagnet(double maxForce, double maxDistance)
        {
            HapticMaterial_SetMagnetMaxForce(ptr, maxForce);
            HapticMaterial_SetMagnetMaxDistance(ptr, maxDistance);
        }

        public void SetVibration(double frequency, double amplitude)
        {
            HapticMaterial_SetVibrationFrequency(ptr, frequency);
            HapticMaterial_SetVibrationAmplitude(ptr, amplitude);
        }

        public void SetHapticTriangleSides(bool enableFront, bool enableBack)
        {
            HapticMaterial_SetHapticTriangleSides(ptr, enableFront, enableBack);
        }


        [DllImport("ChaiTeaLib", EntryPoint = "HapticMaterial_Create")]
        internal static extern IntPtr HapticMaterial_Create();

        [DllImport("ChaiTeaLib", EntryPoint = "HapticMaterial_SetStiffness")]
        internal static extern bool HapticMaterial_SetStiffness(IntPtr pMaterial, double stiffness);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticMaterial_SetDamping")]
        internal static extern bool HapticMaterial_SetDamping(IntPtr pMaterial, double damping);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticMaterial_SetViscosity")]
        internal static extern bool HapticMaterial_SetViscosity(IntPtr pMaterial, double viscosity);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticMaterial_SetStaticFriction")]
        internal static extern bool HapticMaterial_SetStaticFriction(IntPtr pMaterial, double staticFriction);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticMaterial_SetDynamicFriction")]
        internal static extern bool HapticMaterial_SetDynamicFriction(IntPtr pMaterial, double dynamicFriction);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticMaterial_SetVibrationFrequency")]
        internal static extern bool HapticMaterial_SetVibrationFrequency(IntPtr pMaterial, double vibrationFrequency);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticMaterial_SetVibrationAmplitude")]
        internal static extern bool HapticMaterial_SetVibrationAmplitude(IntPtr pMaterial, double vibrationAmplitude);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticMaterial_SetMagnetMaxForce")]
        internal static extern bool HapticMaterial_SetMagnetMaxForce(IntPtr pMaterial, double maxForce);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticMaterial_SetMagnetMaxDistance")]
        internal static extern bool HapticMaterial_SetMagnetMaxDistance(IntPtr pMaterial, double maxDistance);


        [DllImport("ChaiTeaLib", EntryPoint = "HapticMaterial_SetStickSlipForceMax")]
        public static extern bool HapticMaterial_SetStickSlipMaxForce(IntPtr pMaterial, double maxForce);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticMaterial_SetStickSlipStiffness")]
        internal static extern bool HapticMaterial_SetStickSlipStiffness(IntPtr pMaterial, double stiffness);


        [DllImport("ChaiTeaLib", EntryPoint = "HapticMaterial_SetHapticTriangleSides")]
        internal static extern void HapticMaterial_SetHapticTriangleSides(IntPtr pMaterial, bool enableFrontside, bool enableBackside);

    }
}
