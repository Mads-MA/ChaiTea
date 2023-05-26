using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Linq;
using System;


namespace ChaiTea
{
    public class Mesh : GenericObject
    {
        public Mesh(UnityEngine.Mesh unityMesh) : base(Mesh_Create())
        {
            Mesh_FromUnityMesh(
                ptr,
                unityMesh.vertices.Select(v => (Vec3)v).ToArray(), //No implicit cast between Vector3[] and Vec3[]. Copy instead
                unityMesh.vertices.Length,
                unityMesh.normals.Select(n => (Vec3)n).ToArray(), //No implicit cast between Vector3[] and Vec3[]. Copy instead
                unityMesh.normals.Length,
                unityMesh.triangles,
                unityMesh.triangles.Length
                );
            CreateAABBCollisionDetector(GenericTool.toolRadius);
        }

        public Mesh(IntPtr pMesh) : base(pMesh)
        {}

        protected void CreateAABBCollisionDetector(double toolRadius)
        {
            Mesh_CreateAABBCollisionDetector(ptr, toolRadius);
        }

        public void SetScale(Vec3 scale)
        {
            Mesh_ScaleXYZ(ptr, scale);
            CreateAABBCollisionDetector(GenericTool.toolRadius);
        }

        public static Mesh CreatePlane(double x, double z)
        {
            Mesh mesh = new Mesh(Mesh_Create());
            Mesh_CreatePlane(mesh.ptr, x, z);
            mesh.CreateAABBCollisionDetector(GenericTool.toolRadius);
            return mesh;
        }


        [DllImport("ChaiTeaLib", EntryPoint = "Mesh_Create")]
        internal static extern IntPtr Mesh_Create();

        [DllImport("ChaiTeaLib", EntryPoint = "Mesh_FromUnityMesh")]
        internal static extern void Mesh_FromUnityMesh(IntPtr pMesh, Vec3[] vertices, int vertCount, Vec3[] normals, int normalCount, int[] triangles, int trisCount);

        [DllImport("ChaiTeaLib", EntryPoint = "Mesh_CreatePlane")]
        internal static extern void Mesh_CreatePlane(IntPtr pMesh, double lengthX, double lengthY);

        [DllImport("ChaiTeaLib", EntryPoint = "Mesh_CreateAABBCollisionDetector")]
        internal static extern void Mesh_CreateAABBCollisionDetector(IntPtr pMesh, double toolRadius);

        [DllImport("ChaiTeaLib", EntryPoint = "Mesh_ScaleXYZ")]
        internal static extern void Mesh_ScaleXYZ(IntPtr pMesh, Vec3 scale);
    }
}