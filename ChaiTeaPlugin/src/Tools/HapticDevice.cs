using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ChaiTea
{


    public class HapticDevice
    {
        public static int DefaultDeviceIndex { get; protected set; } = -1;
        public static double DefaultWorkspaceFactor { get; protected set; } = -1;
            
        private int deviceIndex;
        private double workspaceScaleFactor;

        private double maxStiffness;
        private double maxDamping;
        private double maxLinearForce;

        public double MaxStiffness { get => maxStiffness;}
        public double MaxDamping { get => maxDamping;}
        public double MaxLinearForce { get => maxLinearForce; }

        public HapticDevice (int deviceIndex, double workspaceScaleFactor)
        {
            if (DefaultDeviceIndex == -1)
                DefaultDeviceIndex = deviceIndex;

            if (DefaultWorkspaceFactor == -1)
                DefaultWorkspaceFactor = workspaceScaleFactor;

            this.deviceIndex = deviceIndex;
            this.workspaceScaleFactor = workspaceScaleFactor;
            this.maxDamping = HapticDevice.HapticDevice_MaxDamping(deviceIndex, workspaceScaleFactor);
            this.maxStiffness = HapticDevice.HapticDevice_MaxStiffness(deviceIndex, workspaceScaleFactor);
            this.maxLinearForce = HapticDevice.HapticDevice_MaxLinearForce(deviceIndex);

            //Debug.Log($"stiff: {MaxStiffness}, damp: {MaxDamping}, lin:{MaxLinearForce}");
        }


        [DllImport("ChaiTeaLib", EntryPoint = "HapticDevice_SetEnableGripperUserSwitch")]
        public static extern bool HapticDevice_SetEnableGripperUserSwitch(int deviceIndex, bool state);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticDevice_MaxLinearForce")]
        public static extern double HapticDevice_MaxLinearForce(int deviceIndex);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticDevice_MaxStiffness")]
        public static extern double HapticDevice_MaxStiffness(int deviceIndex, double workspaceScaleFactor);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticDevice_MaxDamping")]
        public static extern double HapticDevice_MaxDamping(int deviceIndex, double workspaceScaleFactor);

        [DllImport("ChaiTeaLib", EntryPoint = "HapticDevice_GetDeviceInfo")]
        public static extern HapticDeviceInfo GetDeviceInfo(int deviceIndex);
    }
}
