#pragma once
#define DllExport   __declspec( dllexport )


#include "chai3d.h"
#include "Types.hpp"

using namespace chai3d;


#ifdef __cplusplus
extern "C" {
#endif
	//Object hierarchy
	DllExport bool GenericObject_AddChild(cGenericObject* object, cGenericObject* childToAdd);
	DllExport bool GenericObject_RemoveChild(cGenericObject* object, cGenericObject* childToRemove);
	DllExport cGenericObject* GenericObject_GetParent(cGenericObject* object);

	// ---- Generic object functions ---- //
	//Effects
	DllExport bool GenericObject_CreateEffect(cGenericObject* object, EffectType effect);
	DllExport void GenericObject_SetMaterial(cGenericObject* object, cMaterial* material);
	DllExport cMaterial* GenericObject_GetMaterial(cGenericObject* object);

	//Enable/Disable object
	DllExport void GenericObject_SetEnabled(cGenericObject* object, bool enabled, bool affectChildren);
	DllExport bool GenericObject_GetEnabled(cGenericObject* object);

	DllExport void GenericObject_UpdateBoundaryBox(cGenericObject* object, bool includeChildren);
	DllExport void GenericObject_SetUseCulling(cGenericObject* object, bool useCulling, bool affectChildren);

	// Position/Rotation related functions
	DllExport void GenericObject_SetLocalPosition(cGenericObject* object, Vec3 newPosition);
	DllExport Vec3 GenericObject_GetLocalPosition(cGenericObject* object);
	DllExport Vec3 GenericObject_GetGlobalPosition(cGenericObject* object);
	DllExport void GenericObject_SetQuaternion(cGenericObject* object, Vec4 q);
	DllExport Vec4 GenericObject_GetQuaternion(cGenericObject* object);
	DllExport void GenericObject_ScaleObject(cGenericObject* object, double scale);

	DllExport void GenericObject_DeleteAllChildren(cGenericObject* object);
	DllExport void GenericObject_Delete(cGenericObject* object);

#ifdef __cplusplus
}
#endif