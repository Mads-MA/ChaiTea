using System.Runtime.InteropServices;

namespace ChaiTea
{
    public class HapticDevice
    {
        public static HapticDeviceInfo GetDeviceInfo(int deviceIndex)
        {
            return HapticDevice_GetDeviceInfo(deviceIndex);
        }


        [DllImport("ChaiTeaLib", EntryPoint = "HapticDevice_SetEnableGripperUserSwitch")]
        protected static extern bool HapticDevice_SetEnableGripperUserSwitch(int deviceIndex, bool state);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticDevice_MaxLinearForce")]
        protected static extern double HapticDevice_MaxLinearForce(int deviceIndex);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticDevice_MaxStiffness")]
        protected static extern double HapticDevice_MaxStiffness(int deviceIndex, double workspaceScaleFactor);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticDevice_MaxDamping")]
        protected static extern double HapticDevice_MaxDamping(int deviceIndex, double workspaceScaleFactor);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticDevice_GetDeviceInfo")]
        protected static extern HapticDeviceInfo HapticDevice_GetDeviceInfo(int deviceIndex);
    }
}
