#pragma once
#define DllExport   __declspec( dllexport )


#include "chai3d.h"
#include "Types.hpp"
using namespace chai3d;


#ifdef __cplusplus
extern "C" {
#endif
	struct GripperPose
	{
		Vec3 thumbPosition;
		Vec3 fingerPosition;
	};
	//Cursor tool
	DllExport cToolGripper* ToolGripper_Create(cWorld* worldObj);
	DllExport GripperPose ToolGripper_GetProxyPosition(cToolGripper* tool);
	DllExport GripperPose ToolGripper_GetDevicePosition(cToolGripper* tool);
	DllExport void ToolGripper_SetGripperWorkspaceScale(cToolGripper* tool, double gripperWorkspaceScale);
	DllExport double ToolGripper_GetGripperWorkspaceScale(cToolGripper* tool);
	DllExport Vec4 ToolGripper_GetQuaternion(cToolCursor* tool);
#ifdef __cplusplus
}
#endif