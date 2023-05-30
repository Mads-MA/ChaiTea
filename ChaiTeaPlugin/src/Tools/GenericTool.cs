using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ChaiTea
{
    public class GenericTool : GenericObject
    {
        //Some components require tool radius when building AABB etc.
        //Instead of having unity deal with references between components can we just 
        //assign it as static here and assume tools will use the same radius. 
        public static double toolRadius = -1;

        protected GenericTool(IntPtr pTool) : base(pTool)
        { }

        public virtual void UpdateFromDevice()
        {
            GenericTool_UpdateFromDevice(ptr);
        }

        public void ComputeInteractionForces()
        {
            GenericTool_ComputeInteractionForces(ptr);
        }

        public bool ApplyToDevice()
        {
            return GenericTool_ApplyToDevice(ptr);
        }

        public void SetDeviceForce(Vector3 force)
        {
            GenericTool_SetDeviceGlobalForce(ptr, force);
        }

        public bool GetButtonState(int buttonIndex)
        {
            return GenericTool_IsButtonPressed(ptr, buttonIndex);
        }

        public void StartServo()
        {
            GenericTool_Start(ptr);
        }

        public void StopServo()
        {
            GenericTool_Stop(ptr);
        }

        public void SetWorkspaceRadius(double workspaceRadius)
        {
            GenericTool_SetWorkspaceRadius(ptr, workspaceRadius);
        }

        public virtual void SetToolRadius(double toolRadius)
        {
            GenericTool.toolRadius = toolRadius;
            GenericTool_SetToolRadius(ptr, toolRadius);
        }

        public void WaitForSmallForce(bool wait)
        {
            GenericTool_WaitForSmallForce(ptr, wait);
        }


        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_UpdateFromDevice")]
        protected static extern void GenericTool_UpdateFromDevice(IntPtr pTool);


        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_ComputeInteractionForces")]
        protected static extern void GenericTool_ComputeInteractionForces(IntPtr pTool);


        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_ApplyToDevice")]
        protected static extern bool GenericTool_ApplyToDevice(IntPtr pTool);


        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_SetDeviceGlobalForce")]
        protected static extern void GenericTool_SetDeviceGlobalForce(IntPtr pTool, Vec3 force);

        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_WaitForSmallForce")]
        protected static extern void GenericTool_WaitForSmallForce(IntPtr pTool, bool wait);


        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_Stop")]
        protected static extern void GenericTool_Stop(IntPtr pTool);


        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_Start")]
        protected static extern void GenericTool_Start(IntPtr pTool);


        //Checks whether button {buttonID} is pressed or not
        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_IsbuttonPressed")]
        protected static extern bool GenericTool_IsButtonPressed(IntPtr pTool, int buttonID);


        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_SetWorkspaceRadius")]
        protected static extern void GenericTool_SetWorkspaceRadius(IntPtr pTool, double workspaceRadius);


        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_SetToolRadius")]
        protected static extern void GenericTool_SetToolRadius(IntPtr pTool, double toolRadius);

        //Transform
        //[DllImport("ChaiTeaLib", EntryPoint = "Tool_GetDeviceGlobalRotation")]
        //protected static extern Vec4 Tool_GetDeviceGlobalRotation(IntPtr pTool);

        ////
        //[DllImport("ChaiTeaLib", EntryPoint = "Tool_ConfigureCursor")]
        //protected static extern bool Tool_ConfigureCursor(IntPtr pTool, int deviceIndex, double workspaceRadius, double toolRadius, bool enableDynamicObjects, bool allowVirtualDevice = false);

        //[DllImport("ChaiTeaLib", EntryPoint = "Tool_WorkspaceScaleFactor")]
        //protected static extern double Tool_WorkspaceScaleFactor(IntPtr pTool);


        ////Checks whether button on tool, at buttonID/index, is pressed or not
        //[DllImport("ChaiTeaLib", EntryPoint = "Tool_IsbuttonPressed")]
        //protected static extern bool Tool_IsButtonPressed(IntPtr pTool, int buttonID);

        ////Get number of haptic points on tool
        //[DllImport("ChaiTeaLib", EntryPoint = "Tool_GetNumHapticPoints")]
        //protected static extern int Tool_GetNumHapticPoints(IntPtr pTool);

        ////Returns HapticPoint at index of given tool
        //[DllImport("ChaiTeaLib", EntryPoint = "Tool_GetHapticPoint")]
        //protected static extern IntPtr Tool_GetHapticPoint(IntPtr pTool, int hapticPointIndex);

        ////Set force of device
        //[DllImport("ChaiTeaLib", EntryPoint = "Tool_SetDeviceGlobalForce")]
        //protected static extern void Tool_SetDeviceGlobalForce(IntPtr pTool, Vec3 force);

        ////Get force applied to device
        //[DllImport("ChaiTeaLib", EntryPoint = "Tool_GetDeviceGlobalForce")]
        //protected static extern Vec3 Tool_GetDeviceGlobalForce(IntPtr pTool);

        ////Get global transform of device. Not corrected for Unity's coordinate system
        //[DllImport("ChaiTeaLib", EntryPoint = "Tool_GetDeviceGlobalTransform")]
        //protected static extern ChaiTransform Tool_GetDeviceGlobalTransform(IntPtr pTool);


        //[DllImport("ChaiTeaLib", EntryPoint = "Tool_ToolToObjectTransform")]
        //protected static extern ChaiTransform Tool_ToolToObjectTransform(IntPtr pTool, IntPtr pObject);

    }
}
