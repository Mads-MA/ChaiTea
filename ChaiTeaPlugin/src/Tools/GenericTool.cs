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

        public Vector3 GetDeviceForce()
        {
            return GenericTool_GetDeviceGlobalForce(ptr);
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

        public virtual void SetDevicePosition(Vector3 position)
        {
            GenericTool_SetDeviceGlobalPosition(ptr, position);
        }

        public virtual Vector3 GetDevicePosition()
        {
            return GenericTool_GetDeviceGlobalPosition(ptr);
        }

        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_UpdateFromDevice")]
        protected static extern void GenericTool_UpdateFromDevice(IntPtr pTool);


        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_ComputeInteractionForces")]
        protected static extern void GenericTool_ComputeInteractionForces(IntPtr pTool);


        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_ApplyToDevice")]
        protected static extern bool GenericTool_ApplyToDevice(IntPtr pTool);


        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_SetDeviceGlobalForce")]
        protected static extern void GenericTool_SetDeviceGlobalForce(IntPtr pTool, Vec3 force);


        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_GetDeviceGlobalForce")]
        protected static extern Vec3 GenericTool_GetDeviceGlobalForce(IntPtr pTool);


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


        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_SetDeviceGlobalPosition")]
        protected static extern void GenericTool_SetDeviceGlobalPosition(IntPtr pTool, Vec3 position);


        [DllImport("ChaiTeaLib", EntryPoint = "GenericTool_GetDeviceGlobalPosition")]
        protected static extern Vec3 GenericTool_GetDeviceGlobalPosition(IntPtr pTool);
    }
}
