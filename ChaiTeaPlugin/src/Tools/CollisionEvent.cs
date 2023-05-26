using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ChaiTea
{
    public class CollisionEvent
    {
        protected IntPtr self;
        public CollisionEvent(IntPtr self)
        {
            this.self = self;
        }

        public GenericObject GetCollisionObject()
        {
            IntPtr collisionObjPtr = CollisionEvent_GetCollisionObject(self);
            return new GenericObject(collisionObjPtr);
        }

        public Vector3 GetGlobalPosition()
        {
            return CollisionEvent_GetGlobalPosition(self);
        }

        //get object of collision event
        [DllImport("ChaiTeaLib", EntryPoint = "CollisionEvent_GetCollisionObject")]
        internal static extern IntPtr CollisionEvent_GetCollisionObject(IntPtr pCollisionEvent);
        
        //global position of collision event
        [DllImport("ChaiTeaLib", EntryPoint = "CollisionEvent_GetGlobalPosition")]
        internal static extern Vec3 CollisionEvent_GetGlobalPosition(IntPtr pCollisionEvent);
    }
}
