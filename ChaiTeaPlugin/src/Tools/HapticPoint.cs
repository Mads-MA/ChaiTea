using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using UnityEngine;


namespace ChaiTea
{
    public class HapticPoint
    {
        protected IntPtr self;
        public HapticPoint(IntPtr self)
        {
            this.self = self;
        }

        public int GetNumberOfCollisions()
        {
            return HapticPoint_GetNumCollisionEvents(self);
        }

        public CollisionEvent GetCollisionEvent(int index)
        {
            if (index >= GetNumberOfCollisions())
            {
                throw new IndexOutOfRangeException($"Tried to access collision event at index: {index}, but there exist only {GetNumberOfCollisions()} collision events");
            }
            return new CollisionEvent(HapticPoint_GetCollisionEvent(self, index));
        }

        public Vector3 GetLastComputedForce()
        {
            return HapticPoint_GetLastComputedForce(self);
        }

        //Get number of collision events from a single haptic point
        [DllImport("ChaiTeaLib", EntryPoint = "HapticPoint_GetNumCollisionEvents")]
        protected static extern int HapticPoint_GetNumCollisionEvents(IntPtr pHapticPoint);
        
        //Get specific collision event at index
        [DllImport("ChaiTeaLib", EntryPoint = "HapticPoint_GetCollisionEvent")]
        protected static extern IntPtr HapticPoint_GetCollisionEvent(IntPtr pHapticPoint, int collisionEventIndex);


        [DllImport("ChaiTeaLib", EntryPoint = "HapticPoint_GetLastComputedForce")]
        protected static extern Vec3 HapticPoint_GetLastComputedForce(IntPtr pHapticPoint);
    }
}
