#pragma once



#include "GenericTool.hpp"
#include "Types.hpp"
#include "Util.hpp"
#include "Simulation.hpp"
#include "HapticDevice.hpp"

using namespace chai3d;


cHapticDeviceHandler* GenericTool_deviceHandler = nullptr;


extern "C" {
    void GenericTool_UpdateFromDevice(chai3d::cGenericTool* pTool)
    {
        pTool->updateFromDevice();
    }

    void GenericTool_ComputeInteractionForces(chai3d::cGenericTool* pTool)
    {
        pTool->computeInteractionForces();
    }

    void GenericTool_ApplyToDevice(chai3d::cGenericTool* pTool)
    {
        pTool->applyToDevice();
    }

    void GenericTool_SetToolRadius(chai3d::cGenericTool* pTool, double toolRadius)
    {
        pTool->setRadius(toolRadius);
    }

    void GenericTool_SetWorkspaceRadius(chai3d::cGenericTool* pTool, double workspace)
    {
        pTool->setWorkspaceRadius(workspace);
    }


    bool GenericTool_IsbuttonPressed(cGenericTool* tool, int buttonID)
    {
        return tool->getUserSwitch(buttonID);
    }

    Vec4 GenericTool_GetDeviceGlobalRotation(cGenericTool* tool)
    {
        return ConvertRotationMatrixToUnity(tool->getDeviceGlobalRot());
    }

    void GenericTool_WaitForSmallForce(cGenericTool* pTool, bool wait)
    {
        pTool->setWaitForSmallForce(wait);
    }

    void GenericTool_Start(cGenericTool* tool)
    {
        tool->start();
    }

    void GenericTool_Stop(cGenericTool* tool)
    {
        tool->stop();
    }

    double GenericTool_WorkspaceScaleFactor(cGenericTool* tool)
    {
        return tool->getWorkspaceScaleFactor();
    }

    int GenericTool_GetNumHapticPoints(cGenericTool* tool)
    {
        return tool->getNumHapticPoints();
    }

    cHapticPoint* GenericTool_GetHapticPoint(cGenericTool* tool, int hapticPointIndex)
    {
        return tool->getHapticPoint(hapticPointIndex);
    }

    int HapticPoint_GetNumCollisionEvents(cHapticPoint* hapticPoint)
    {
        return hapticPoint->getNumCollisionEvents();
    }

    cCollisionEvent* HapticPoint_GetCollisionEvent(cHapticPoint* hapticPoint, int eventIndex)
    {
        return hapticPoint->getCollisionEvent(eventIndex);
    }

    Vec3 HapticPoint_GetLastComputedForce(cHapticPoint* hapticPoint)
    {
        cVector3d cForce = hapticPoint->getLastComputedForce();
        Vec3 force = ConvertXYZToUnity(cForce);
        return force;
    }

    cGenericObject* CollisionEvent_GetCollisionObject(cCollisionEvent* collisionEvent)
    {
        return collisionEvent->m_object;
    }

    Vec3 CollisionEvent_GetGlobalPosition(cCollisionEvent* collisionEvent)
    {
        Vec3 globalPosition = ConvertXYZToUnity(collisionEvent->m_globalPos);
        return globalPosition;
    }

    void GenericTool_SetDeviceGlobalForce(cGenericTool* tool, Vec3 force)
    {
        cVector3d cForce = ConvertXYZToCHAI3D(force);
        tool->setDeviceGlobalForce(cForce);
    }

    Vec3 GenericTool_GetDeviceGlobalForce(cGenericTool* tool)
    {
        cVector3d force = tool->getDeviceGlobalForce();
        return ConvertXYZToUnity(force);
    }
    Vec3 GenericTool_GetDeviceGlobalPosition(chai3d::cGenericTool* pTool)
    {
        cVector3d position = pTool->getDeviceGlobalPos();
        return ConvertXYZToUnity(position);
    }
    
    void GenericTool_SetDeviceGlobalPosition(chai3d::cGenericTool* pTool, Vec3 position)
    {
        cVector3d cPos = ConvertXYZToCHAI3D(position);
        pTool->setDeviceGlobalPos(cPos);
    }
}