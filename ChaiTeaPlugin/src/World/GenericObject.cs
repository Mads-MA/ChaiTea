using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Runtime.InteropServices;

namespace ChaiTea
{
    public class GenericObject
    {
        protected IntPtr ptr = IntPtr.Zero;
        public IntPtr Pointer { get => ptr; }
        public bool Initialized { get => ptr != IntPtr.Zero; }
       

        public Vector3 GetLocalPosition()
        {
            return GenericObject_GetLocalPosition(ptr);
        }

        public void SetLocalPosition(Vector3 position)
        {
            GenericObject_SetLocalPosition(ptr, position);
        }

        public Vector3 GetGlobalPosition()
        {
            return GenericObject_GetGlobalPosition(ptr);
        }
        
        public Quaternion GetRotation()
        {
            return (Quaternion)GenericObject_GetQuaternion(ptr);
        }

        public void SetRotation(Quaternion rotation)
        {
            GenericObject_SetQuaternion(ptr, rotation);
        }

        public GenericObject(IntPtr objectPtr)
        {
            this.ptr = objectPtr;
        }

        public virtual void AddChild(GenericObject child)
        {
            GenericObject_AddChild(ptr, child.ptr);
        }
        
        public virtual void RemoveChild(GenericObject childToRemove)
        {
            GenericObject_RemoveChild(ptr, childToRemove.ptr);
        }

        public virtual GenericObject GetParent()
        {
            IntPtr parentPtr = GenericObject_GetParent(ptr);
            return new GenericObject(parentPtr);
        }

        public void UpdateBoundaryBox(bool includeChildren = false)
        {
            GenericObject_UpdateBoundaryBox(ptr, includeChildren);
        }

        public bool IsEnabled()
        {
            return GenericObject_GetEnabled(ptr);
        }

        public void SetActive(bool enabled, bool includeChildren = false)
        {
            GenericObject_SetEnabled(ptr, enabled, includeChildren);
        }

        public void ScaleObject(double scale)
        {
            GenericObject_ScaleObject(ptr, scale);
        }

        public void SetHapticMaterial(HapticMaterial material)
        {
            GenericObject_SetMaterial(ptr, material.Pointer);
        }

        public HapticMaterial GetHapticMaterial()
        {
            return new HapticMaterial(GenericObject_GetMaterial(ptr));
        }

        public void CreateEffect(EffectType hapticEffect)
        {
            GenericOBject_CreateEffect(ptr, hapticEffect);
        }

        //Haptic effects and properties
        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_CreateEffect")]
        internal static extern bool GenericOBject_CreateEffect(IntPtr pObject, EffectType effect);

        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_SetMaterial")]
        internal static extern void GenericObject_SetMaterial(IntPtr pObject, IntPtr pMaterial);

        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_GetMaterial")]
        internal static extern IntPtr GenericObject_GetMaterial(IntPtr pObject);

        //Object hierachy
        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_AddChild")]
        internal static extern void GenericObject_AddChild(IntPtr pObject, IntPtr pChildToAdd);

        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_RemoveChild")]
        internal static extern void GenericObject_RemoveChild(IntPtr pObject, IntPtr pChildToRemove);


        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_GetOwner")]
        internal static extern IntPtr GenericObject_GetOwner(IntPtr pObject);

        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_SetParent")]
        internal static extern void GenericOBject_SetParent(IntPtr ptr);

        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_GetParent")]
        internal static extern IntPtr GenericObject_GetParent(IntPtr pObject);

        //Enable or disable object from being haptically rendered.
        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_SetEnabled")]
        internal static extern void GenericObject_SetEnabled(IntPtr pObject, bool enabled, bool affectChildren);

        //See if an object is haptically rendered or not
        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_GetEnabled")]
        internal static extern bool GenericObject_GetEnabled(IntPtr pObject);

        //Position
        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_GetGlobalPosition")]
        internal static extern Vec3 GenericObject_GetGlobalPosition(IntPtr pObject);

        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_GetLocalPosition")]
        internal static extern Vec3 GenericObject_GetLocalPosition(IntPtr pObject);

        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_SetLocalPosition")]
        internal static extern void GenericObject_SetLocalPosition(IntPtr pObject, Vec3 localPosition);

        //Rotation
        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_GetQuaternion")]
        internal static extern Vec4 GenericObject_GetQuaternion(IntPtr pObject);


        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_SetQuaternion")]
        internal static extern void GenericObject_SetQuaternion(IntPtr pObject, Vec4 quaternion);

        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_ScaleObject")]
        internal static extern void GenericObject_ScaleObject(IntPtr pObject, double scale);

        //Collision etc
        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_UpdateBoundaryBox")]
        internal static extern void GenericObject_UpdateBoundaryBox(IntPtr pObject, bool includeChildren);

        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_SetNewTransform")]
        internal static extern void GenericObject_SetNewTransform(IntPtr pObject, ChaiTransform transform);

        [DllImport("ChaiTeaLib", EntryPoint = "GenericObject_DeleteAllChildren")]
        internal static extern void GenericObject_DeleteAllChildren(IntPtr pObject);


    }

    [System.Flags]
    public enum EffectType
    {
        None = 0,
        Magnet = 1,
        StickSlip = 1 << 1,
        Surface = 1 << 2,
        Vibration = 1 << 3,
        Viscosity = 1 << 4,
    }

}
