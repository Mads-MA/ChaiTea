#pragma once
#define DllExport   __declspec( dllexport )


#include "chai3d.h"
#include "Types.hpp"


#ifdef __cplusplus
extern "C" {
#endif
	DllExport void GenericTool_SetToolRadius(chai3d::cGenericTool* pTool, double toolRadius);
	DllExport void GenericTool_SetWorkspaceRadius(chai3d::cGenericTool* pTool, double workspace);

	DllExport void GenericTool_Start(chai3d::cGenericTool* pTool);
	DllExport void GenericTool_Stop(chai3d::cGenericTool* pTool);

	DllExport bool GenericTool_IsbuttonPressed(chai3d::cGenericTool* pTool, int buttonID);

	DllExport void GenericTool_ComputeInteractionForces(chai3d::cGenericTool* pTool);
	DllExport void GenericTool_ApplyToDevice(chai3d::cGenericTool* pTool);
	DllExport void GenericTool_UpdateFromDevice(chai3d::cGenericTool* pTool);

	DllExport void GenericTool_WaitForSmallForce(chai3d::cGenericTool* pTool, bool wait);


	//DeviceState
	DllExport Vec4 GenericTool_GetDeviceGlobalRotation(chai3d::cGenericTool* pTool);
	DllExport void GenericTool_SetDeviceGlobalForce(chai3d::cGenericTool* pTool, Vec3 force);
	DllExport Vec3 GenericTool_GetDeviceGlobalForce(chai3d::cGenericTool* pTool);
	DllExport Vec3 GenericTool_GetDeviceGlobalPosition(chai3d::cGenericTool* pTool);
	DllExport void GenericTool_SetDeviceGlobalPosition(chai3d::cGenericTool* pTool, Vec3 position);


	DllExport double GenericTool_WorkspaceScaleFactor(chai3d::cGenericTool* tool);

	//Interaction and collision
	DllExport int GenericTool_GetNumHapticPoints(chai3d::cGenericTool* tool);
	DllExport chai3d::cHapticPoint* GenericTool_GetHapticPoint(chai3d::cGenericTool* tool, int hapticPointIndex);

	//TODO move
	DllExport int HapticPoint_GetNumCollisionEvents(chai3d::cHapticPoint* hapticPoint);
	DllExport chai3d::cCollisionEvent* HapticPoint_GetCollisionEvent(chai3d::cHapticPoint* hapticPoint, int eventIndex);
	DllExport Vec3 HapticPoint_GetLastComputedForce(chai3d::cHapticPoint* hapticPoint);
	DllExport chai3d::cGenericObject* CollisionEvent_GetCollisionObject(chai3d::cCollisionEvent* collisionEvent);
	DllExport Vec3 CollisionEvent_GetGlobalPosition(chai3d::cCollisionEvent* collisionEvent);

#ifdef __cplusplus
}
#endif