using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using UnityEngine;


namespace ChaiTea
{
    public class ToolCursor : GenericTool
    {
        public ToolCursor(GenericObject worldObject, int deviceIndex)
            : base(ToolCursor_Create(worldObject.Pointer, deviceIndex))
        {
            worldObject.AddChild(this);
        }

        public Vector3 GetProxyPosition()
        {
            return ToolCursor_GetProxyPosition(ptr);
        }

        public Vector3 GetDevicePosition()
        {
            return ToolCursor_GetDevicePosition(ptr);
        }

        
        [DllImport("ChaiTeaLib", EntryPoint = "ToolCursor_Create")]
        public static extern IntPtr ToolCursor_Create(IntPtr pWorldObject, int deviceIndex);

        //Proxy position is the point where the tool should be given the finger proxy algorithm
        [DllImport("ChaiTeaLib", EntryPoint = "ToolCursor_GetProxyPosition")]
        public static extern Vec3 ToolCursor_GetProxyPosition(IntPtr pToolCursor);

        //Device position is the "correct" position of the device 
        [DllImport("ChaiTeaLib", EntryPoint = "ToolCursor_GetDevicePosition")]
        public static extern Vec3 ToolCursor_GetDevicePosition(IntPtr pToolCursor);

        //Device rotation in euler angles from quaternion.
        //No easy way to get euler angles where coordinate system can be fixed,
        //So return quaternion, where we in unity easily can get the eulerangles and fix coordinate system.
        [DllImport("ChaiTeaLib", EntryPoint = "ToolCursor_GetQuaternion")]
        public static extern Vec4 ToolCursor_GetQuaternion(IntPtr pToolCursor);
    }
}
