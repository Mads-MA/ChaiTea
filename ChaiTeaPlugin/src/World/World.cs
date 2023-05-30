using System;
using System.Runtime.InteropServices;

namespace ChaiTea
{
    public class World : GenericObject
    {
        public World() : base(World_Create())
        {}
        
        public void ComputeGlobalPositions(bool frameOnly)
        {
            World_ComputeGlobalPositions(ptr, frameOnly);
        }

        //Calling this will invalidate all generic objects.
        //Ideally we would be able to invalidate all generic objects when calling reset on root
        //but can we actually do that?
        public void Reset()
        {
            GenericObject_DeleteAllChildren(ptr);   
        }

        [DllImport("ChaiTeaLib", EntryPoint = "World_Create")]
        internal static extern IntPtr World_Create();

        [DllImport("ChaiTeaLib", EntryPoint = "World_ComputeGlobalPositions")]
        internal static extern void World_ComputeGlobalPositions(IntPtr pWorld, bool frameOnly);
    }
}
