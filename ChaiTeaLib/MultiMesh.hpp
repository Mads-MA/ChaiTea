#pragma once
#define DllExport __declspec( dllexport )

#include "chai3d.h"

#ifdef __cplusplus
extern "C" {
#endif
	DllExport chai3d::cMultiMesh* MultiMesh_Create();

	DllExport void MultiMesh_UseCulling(chai3d::cMultiMesh* self, bool useCulling, bool affectChildren = false);
	DllExport void MultiMesh_CreateAABBCollisionDetector(chai3d::cMultiMesh* self, double radius);
	
	DllExport chai3d::cMesh* MultiMesh_NewMesh(chai3d::cMultiMesh* self);
	DllExport void MultiMesh_AddMesh(chai3d::cMultiMesh* self, chai3d::cMesh* mesh);
	DllExport void MultiMesh_RemoveMesh(chai3d::cMultiMesh* self, chai3d::cMesh* mesh);




#ifdef __cplusplus
}
#endif