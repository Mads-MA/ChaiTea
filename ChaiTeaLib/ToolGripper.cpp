#pragma once

#include "ToolGripper.hpp"
#include "Types.hpp"
#include "Util.hpp"
#include "Simulation.hpp"
#include "HapticDevice.hpp"



extern "C" {

    cToolGripper* ToolGripper_Create(cWorld* worldObj)
    {
        return new cToolGripper(worldObj);
    }

    GripperPose ToolGripper_GetProxyPosition(cToolGripper* tool)
    {
        cVector3d thumpPos = tool->m_hapticPointThumb->getGlobalPosProxy();
        cVector3d fingerPos = tool->m_hapticPointFinger->getGlobalPosProxy();

        return { ConvertXYZToUnity(thumpPos), ConvertXYZToUnity(fingerPos) };
    }

    GripperPose ToolGripper_GetDevicePosition(cToolGripper* tool)
    {
        cVector3d thumpPos = tool->m_hapticPointThumb->getGlobalPosGoal();
        cVector3d fingerPos = tool->m_hapticPointFinger->getGlobalPosGoal();

        return { ConvertXYZToUnity(thumpPos), ConvertXYZToUnity(fingerPos) };
    }

    void ToolGripper_SetGripperWorkspaceScale(cToolGripper* tool, double gripperWorkspaceScale)
    {
        tool->setGripperWorkspaceScale(gripperWorkspaceScale);
    }

    double ToolGripper_GetGripperWorkspaceScale(cToolGripper* tool)
    {
        return tool->getGripperWorskpaceScale();
    }


    Vec4 ToolGripper_GetQuaternion(cToolCursor* tool)
    {
        cQuaternion q;
        q.fromRotMat(tool->getDeviceGlobalRot());
        return ConvertQuaternionToUnity(q);
    }
}