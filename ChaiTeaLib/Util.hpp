#pragma once
#include "chai3d.h"
#include "Types.hpp"
#include <string>
#define DllExport   __declspec( dllexport )

using namespace chai3d;


//Call log in unity
typedef void (*UnityDebugLog)(const char* msg, int severity);

#ifdef __cplusplus
extern "C" {
	//Cursor tool
	DllExport void Util_RegisterLogCallback(UnityDebugLog cb);
}
#endif

bool EnsureFolderExist(const std::string& pathToFolder);

void UnityDebug_Log(const std::string& msg);
void UnityDebug_Warning(const std::string& msg);
void UnityDebug_Error(const std::string& msg);

Vec3 ConvertXYZToUnity(cVector3d& cVec);
Vec3 ConvertXYZToUnity(cVector3d&& cVec);
cVector3d ConvertXYZToCHAI3D(Vec3& vec);
cVector3d ConvertXYZToCHAI3D(Vec3&& vec);


Vec4 ConvertQuaternionToUnity(Vec4& vec);
Vec4 ConvertQuaternionToUnity(const cQuaternion& q);
Vec4 ConvertRotationMatrixToUnity(const cMatrix3d& rotMat);
cQuaternion ConvertQuaternionToCHAI3D(Vec4& vec);


///
/// Helpfull math functions
///

chai3d::cVector3d vecMulHadamard(cVector3d& left, cVector3d& right);
chai3d::cVector3d vecDivisionHadamard(cVector3d& left, cVector3d& right);