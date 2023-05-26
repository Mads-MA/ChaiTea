#pragma once
#define DllExport __declspec( dllexport )

#include "Types.hpp"
#include "GenericObject.hpp"
#include "chai3d.h"

using namespace chai3d;


#ifdef __cplusplus
extern "C" {
#endif
	DllExport cMesh* Mesh_Create();
	DllExport void Mesh_FromUnityMesh(cMesh* mesh, Vec3* vertices, int vertCount, Vec3* normals, int normalCount, int* triangles, int trisCount);
	DllExport void Mesh_CreatePlane(cMesh* mesh, double lengthX, double lengthY);
	DllExport void Mesh_CreateAABBCollisionDetector(cMesh* mesh, double toolRadius);


	DllExport void Mesh_ScaleXYZ(cMesh* mesh, Vec3 scale);

#ifdef __cplusplus
}
#endif