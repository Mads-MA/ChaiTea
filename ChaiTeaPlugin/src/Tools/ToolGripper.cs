using System.Runtime.InteropServices;
using UnityEngine;


namespace ChaiTea
{
    //public class ToolGripper : GenericTool
    //{
    //    public ToolGripper(World world, int deviceIndex) : base(deviceIndex)
    //    {
    //        ptr = ToolGripper_Create(world.Pointer);
    //        if (ptr == IntPtr.Zero)
    //        {
    //            throw new Exception("Failed to create gripper tool");
    //        }
    //    }

    //    public GripperPose GetProxyPosition()
    //    {
    //        return ToolGripper_GetProxyPosition(ptr);
    //    }

    //    public GripperPose GetDevicePosition()
    //    {
    //        return ToolGripper_GetDevicePosition(ptr);
    //    }

    //    public Quaternion GetRotation()
    //    {
    //        return ToolGripper_GetQuaternion(ptr);
    //    }

    //    public double GetWorkspaceScale()
    //    {
    //        return ToolGripper_GetGripperWorkspaceScale(ptr);
    //    }

    //    public void SetWorkspaceScale(double gripperWorkspaceScale)
    //    {
    //        ToolGripper_SetGripperWorkspaceScale(ptr, gripperWorkspaceScale);
    //    }

    //    [DllImport("ChaiTeaLib", EntryPoint = "ToolGripper_Create")]
    //    protected static extern IntPtr ToolGripper_Create(IntPtr pWorldObject);

    //    //Proxy position is the point where the tool should be given the finger proxy algorithm
    //    [DllImport("ChaiTeaLib", EntryPoint = "ToolGripper_GetProxyPosition")]
    //    protected static extern GripperPose ToolGripper_GetProxyPosition(IntPtr pToolGripper);

    //    //Device position is the "correct" position of the device 
    //    [DllImport("ChaiTeaLib", EntryPoint = "ToolGripper_GetDevicePosition")]
    //    protected static extern GripperPose ToolGripper_GetDevicePosition(IntPtr pToolGripper);

    //    //Device rotation in euler angles from quaternion.
    //    //No easy way to get euler angles where coordinate system can be fixed,
    //    //So return quaternion, where we in unity easily can get the eulerangles and fix coordinate system.
    //    [DllImport("ChaiTeaLib", EntryPoint = "ToolGripper_GetQuaternion")]
    //    protected static extern Vec4 ToolGripper_GetQuaternion(IntPtr pToolGripper);

    //    //Gripper workspace scale 
    //    //TODO determine what this does
    //    [DllImport("ChaiTeaLib", EntryPoint = "ToolGripper_GetGripperWorkspaceScale")]
    //    protected static extern double ToolGripper_GetGripperWorkspaceScale(IntPtr pToolGripper);

    //    [DllImport("ChaiTeaLib", EntryPoint = "ToolGripper_SetGripperWorkspaceScale")]
    //    protected static extern void ToolGripper_SetGripperWorkspaceScale(IntPtr pToolGripper, double gripperWorkspaceScale);
    //}
}
