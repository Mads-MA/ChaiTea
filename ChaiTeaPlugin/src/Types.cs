using System.Runtime.InteropServices;
using UnityEngine;

namespace ChaiTea
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3
    {
        public float x;
        public float y;
        public float z;

        //Implicit conversion between Unity' vector3 and position coordinates for Chai3D
        public Vec3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
        public static implicit operator Vector3(Vec3 vec) => new Vector3(vec.x, vec.y, vec.z);
        public static implicit operator Vec3(Vector3 vec) => new Vec3(vec.x, vec.y, vec.z);

        public static Vec3 operator * (Vec3 vec, float scalar)
        {
            return new Vec3
            {
                x = vec.x * scalar,
                y = vec.y * scalar,
                z = vec.z * scalar
            };
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GripperPose
    {
        public Vec3 thumbPosition;
        public Vec3 fingerPosition;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4
    {
        float x;
        float y;
        float z;
        float w;

        //Implicit conversion between Unity' quaternion and quaternion of Chai3D
        public Vec4(float _x, float _y, float _z, float _w)
        {
            x = _x;
            y = _y;
            z = _z;
            w = _w;
        }
        public static implicit operator Quaternion(Vec4 vec) => new Quaternion(vec.x, vec.y, vec.z, vec.w);
        public static implicit operator Vec4(Quaternion q) => new Vec4(q.x, q.y, q.z, q.w);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ChaiTransform
    {
        Vec3 position;
        Vec4 rotation;

        [DllImport("ChaiTeaLib", EntryPoint = "Transform_Mul")]
        public static extern ChaiTransform Mul(ChaiTransform left, ChaiTransform right);

        [DllImport("ChaiTeaLib", EntryPoint = "Transform_Invert")]
        public static extern ChaiTransform Invert(ChaiTransform transform);
    }


    public enum HapticDeviceModel
    {
        C_HAPTIC_DEVICE_VIRTUAL,
        C_HAPTIC_DEVICE_DELTA_3,
        C_HAPTIC_DEVICE_DELTA_6,
        C_HAPTIC_DEVICE_OMEGA_3,
        C_HAPTIC_DEVICE_OMEGA_6,
        C_HAPTIC_DEVICE_OMEGA_7,
        C_HAPTIC_DEVICE_SIGMA_6P,
        C_HAPTIC_DEVICE_SIGMA_7,
        C_HAPTIC_DEVICE_FALCON,
        C_HAPTIC_DEVICE_XTH_1,
        C_HAPTIC_DEVICE_XTH_2,
        C_HAPTIC_DEVICE_MPR,
        C_HAPTIC_DEVICE_KSD_1,
        C_HAPTIC_DEVICE_VIC_1,
        C_HAPTIC_DEVICE_PHANTOM_TOUCH,
        C_HAPTIC_DEVICE_PHANTOM_OMNI,
        C_HAPTIC_DEVICE_PHANTOM_DESKTOP,
        C_HAPTIC_DEVICE_PHANTOM_15_6DOF,
        C_HAPTIC_DEVICE_PHANTOM_30_6DOF,
        C_HAPTIC_DEVICE_PHANTOM_OTHER,
        C_TRACKER_DEVICE_SIXENSE,
        C_TRACKER_DEVICE_LEAP,
        C_HAPTIC_DEVICE_CUSTOM
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct HapticDeviceInfo
    {
        public HapticDeviceModel model;
        public string modelName;
        public string manufacturerName;

        public double maxLinearForce;
        public double maxAngularTorque;
        public double maxGripperForce;

        public double maxLinearStiffness;
        public double maxAngularStiffness;
        public double maxGripperStiffness;

        public double maxLinearDamping;
        public double maxAngularDamping;
        public double maxGripperAngularDamping;


        public double workspaceRadius;

        public double gripperMaxAngleRad;

        public bool sensedPosition;
        public bool sensedRotation;
        public bool sensedGripper;

        public bool actuatedPosition;
        public bool actuatedRotation;
        public bool actuatedGripper;

        public bool leftHand;
        public bool rightHand;

    }

}
