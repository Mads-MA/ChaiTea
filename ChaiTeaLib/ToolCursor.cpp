#pragma once

#include "Types.hpp"
#include "Util.hpp"
#include "Simulation.hpp"
#include "HapticDevice.hpp"
#include "ToolGripper.hpp"

using namespace chai3d;

extern "C" {

    cToolCursor* ToolCursor_Create(cWorld* pWorld, int deviceIndex)
    {
        cGenericHapticDevicePtr device;
        HapticDevice_GetDevice(device, deviceIndex, false);

        cToolCursor* pTool = new cToolCursor(pWorld);
        pTool->setHapticDevice(device);
        return pTool;
    }

    Vec3 ToolCursor_GetProxyPosition(cToolCursor* pTool)
    {
        cVector3d cGlobalPosition = pTool->m_hapticPoint->getGlobalPosProxy();
        //Flip to unity coordinate system
        Vec3 globalPosition = ConvertXYZToUnity(cGlobalPosition);

        return globalPosition;
    }


    Vec3 ToolCursor_GetDevicePosition(cToolCursor* pTool)
    {
        cVector3d cGlobalPosition = pTool->m_hapticPoint->getGlobalPosGoal();
        //Flip to unity coordinate system
        Vec3 globalPosition = ConvertXYZToUnity(cGlobalPosition);

        return globalPosition;
    }

    Vec4 ToolCursor_GetQuaternion(cToolCursor* pTool)
    {
        cQuaternion q;
        q.fromRotMat(pTool->getDeviceGlobalRot());
        return ConvertQuaternionToUnity(q);
    }
}