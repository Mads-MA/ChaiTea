#pragma once
#include "Util.hpp"
#include "chai3d.h"
#include <windows.h>
#include <string>


UnityDebugLog debugLogCallback = nullptr;

void Util_RegisterLogCallback(UnityDebugLog cb)
{
    debugLogCallback = cb;
    UnityDebug_Log("Registered CB for logging in unity console");
}

void UnityDebug_Log(const std::string& msg)
{
    if (debugLogCallback != nullptr)
        debugLogCallback(msg.c_str(), 0);
}

void UnityDebug_Warning(const std::string& msg)
{
    if (debugLogCallback != nullptr)
        debugLogCallback(msg.c_str(), 1);
}

void UnityDebug_Error(const std::string& msg)
{
    if (debugLogCallback != nullptr)
        debugLogCallback(msg.c_str(), 2);
}


bool EnsureFolderExist(const std::string& pathToFolder)
{
    if (CreateDirectoryA(pathToFolder.c_str(), NULL) || ERROR_ALREADY_EXISTS == GetLastError())
        return true;
    return false; //Failed to create directory
}


Vec3 ConvertXYZToUnity(cVector3d& cVec)
{
    //Flip to unity coordinate system
    //Based on https://www.chai3d.org/download/doc/html/chapter7-world.html
    return Vec3{
        static_cast<float>(cVec.y()),
        static_cast<float>(cVec.z()),
        static_cast<float>(-1 * cVec.x())
    };
}

Vec3 ConvertXYZToUnity(cVector3d&& cVec)
{
    //Flip to unity coordinate system
    //Based on https://www.chai3d.org/download/doc/html/chapter7-world.html
    return Vec3{
        static_cast<float>(cVec.y()),
        static_cast<float>(cVec.z()),
        static_cast<float>(-1 * cVec.x())
    };
}

cVector3d ConvertXYZToCHAI3D(Vec3& vec)
{
    //Flip from unity coordinate system
    //Based on https://www.chai3d.org/download/doc/html/chapter7-world.html
    return cVector3d {
        -1 * vec.z,
        vec.x,
        vec.y
    };
}

cVector3d ConvertXYZToCHAI3D(Vec3&& vec)
{
    //Flip from unity coordinate system
    //Based on https://www.chai3d.org/download/doc/html/chapter7-world.html
    return cVector3d{
        -1 * vec.z,
        vec.x,
        vec.y
    };
}



//Count for Unity being right handed coordinate system and Chai3D left handed,
//just flip the coordinates in the quaternion.
Vec4 ConvertQuaternionToUnity(Vec4& vec)
{
    return {
        -1 * vec.y,
        -1 * vec.z,
        vec.x,
        vec.w
    };
}

Vec4 ConvertQuaternionToUnity(const cQuaternion& q)
{
    return {
    -1 * static_cast<float>(q.y),
    -1 * static_cast<float>(q.z),
    static_cast<float>(q.x),
    static_cast<float>(q.w)
    };
}

Vec4 ConvertRotationMatrixToUnity(const cMatrix3d& rotMat)
{
    cQuaternion quat;
    quat.fromRotMat(rotMat);
    return ConvertQuaternionToUnity(quat);
}


//Count for Unity being right handed coordinate system and Chai3D left handed,
//just flip the coordinates in the quaternion.
cQuaternion ConvertQuaternionToCHAI3D(Vec4& vec)
{
    Vec4 fixed = {
        vec.z,
        -1 * vec.x,
        -1 * vec.y,
        vec.w
    };
    return cQuaternion(fixed.w, fixed.x, fixed.y, fixed.z);
}

chai3d::cVector3d vecMulHadamard(cVector3d& left, cVector3d& right)
{
    return {
        left(0) * right(0),
        left(1) * right(1),
        left(2) * right(2)
    };
}
