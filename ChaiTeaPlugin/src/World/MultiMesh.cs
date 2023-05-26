using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ChaiTea
{
    public class MultiMesh : GenericObject
    {
        public MultiMesh() : base(MultiMesh_Create())
        {
        }

        public Mesh NewMesh()
        {
            IntPtr pMesh = MultiMesh_NewMesh(ptr);
            Mesh mesh = new Mesh(pMesh);
            return mesh;
        }

        public void AddMesh(Mesh mesh, double toolRadius)
        {
            MultiMesh_AddMesh(ptr, mesh.Pointer);
            MultiMesh_CreateAABBCollisionDetector(ptr, toolRadius);
        }
        public void RemoveMesh(Mesh mesh, double toolRadius)
        {
            MultiMesh_RemoveMesh(ptr, mesh.Pointer);
            MultiMesh_CreateAABBCollisionDetector(ptr, toolRadius);
        }

        [DllImport("ChaiTeaLib", EntryPoint = "MultiMesh_Create")]
        internal static extern IntPtr MultiMesh_Create();

        [DllImport("ChaiTeaLib", EntryPoint = "MultiMesh_CreateAABBCollisionDetector")]
        internal static extern void MultiMesh_CreateAABBCollisionDetector(IntPtr self, double toolRadius);

        //Returns a pointer point to a new mesh object
        [DllImport("ChaiTeaLib", EntryPoint = "MultiMesh_NewMesh")]
        internal static extern IntPtr MultiMesh_NewMesh(IntPtr self);

        [DllImport("ChaiTeaLib", EntryPoint = "MultiMesh_AddMesh")]
        internal static extern void MultiMesh_AddMesh(IntPtr self, IntPtr pMesh);

        [DllImport("ChaiTeaLib", EntryPoint = "MultiMesh_RemoveMesh")]
        internal static extern void MultiMesh_RemoveMesh(IntPtr self, IntPtr pMeshToRemove);
    }
}
