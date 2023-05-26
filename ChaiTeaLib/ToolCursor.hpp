#pragma once
#define DllExport   __declspec( dllexport )


#include "chai3d.h"
#include "Types.hpp"


#ifdef __cplusplus
extern "C" {
#endif
	//Cursor tool
	DllExport chai3d::cToolCursor* ToolCursor_Create(chai3d::cWorld* pWorld, int deviceIndex);
	DllExport Vec3 ToolCursor_GetProxyPosition(chai3d::cToolCursor* pTool);
	DllExport Vec3 ToolCursor_GetDevicePosition(chai3d::cToolCursor* pTool);
	DllExport Vec4 ToolCursor_GetQuaternion(chai3d::cToolCursor* pTool);
#ifdef __cplusplus
}
#endif