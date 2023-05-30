#pragma once

#include "Types.hpp"
#include "Util.hpp"
#include "Simulation.hpp"
#include "GenericObject.hpp"



extern "C" {
    cGenericObject* GenericObject_CreateBoxShape(Vec3 size)
    {
        cGenericObject* obj = new cShapeBox(size.z, size.x, size.y);
        return obj;
    }

    Vec3 GenericObject_BoxGetSize(cGenericObject* object)
    {
        cShapeBox* box = static_cast<cShapeBox*>(object);
        Vec3 size{
            static_cast<float>(box->getSizeY()),
            static_cast<float>(box->getSizeZ()),
            static_cast<float>(box->getSizeX())
        };

        //Flip to unity coordinate system
        return size;
    }

    bool GenericObject_AddChild(cGenericObject* object, cGenericObject* childToAdd)
    {
        return object->addChild(childToAdd);
    }

    bool GenericObject_RemoveChild(cGenericObject* object, cGenericObject* childToRemove)
    {
        return object->removeChild(childToRemove);
    }

    cGenericObject* GenericObject_GetOwner(cGenericObject* object)
    {
        return object->getOwner();
    }

    cGenericObject* GenericObject_GetParent(cGenericObject* object)
    {
        return object->getParent();
    }

    //Enables or disable haptic and graphic rendering of object.
    void GenericObject_SetEnabled(cGenericObject* object, bool enabled, bool affectChildren)
    {
        object->setEnabled(enabled, affectChildren);
    }

    bool GenericObject_GetEnabled(cGenericObject* object)
    {
        return object->getEnabled();
    } 

    void GenericObject_SetMaterial(cGenericObject* object, cMaterial* material)
    {
        object->setMaterial((cMaterialPtr)material, false);
    }

    cMaterial* GenericObject_GetMaterial(cGenericObject* object)
    {
        return object->m_material.get();
    }

    void GenericObject_UpdateBoundaryBox(cGenericObject* object, bool includeChildren)
    {
        object->computeBoundaryBox(includeChildren);
    }

    void GenericObject_SetUseCulling(cGenericObject* object, bool useCulling, bool affectChildren)
    {
        object->setUseCulling(useCulling, affectChildren);
    }

    void GenericObject_SetLocalPosition(cGenericObject* object, Vec3 newPosition)
    {
        cVector3d cPosition = ConvertXYZToCHAI3D(newPosition);
        object->setLocalPos(cPosition);
    }

    Vec3 GenericObject_GetLocalPosition(cGenericObject* object)
    {
        cVector3d cLocalPosition = object->getLocalPos();
        return ConvertXYZToUnity(cLocalPosition);
    }

    Vec3 GenericObject_GetGlobalPosition(cGenericObject* object)
    {
        cVector3d cGlobalPosition = object->getGlobalPos();
        Vec3 globalPosition = ConvertXYZToUnity(cGlobalPosition);

        //Flip to unity coordinate system
        return globalPosition;
    }



    bool GenericObject_CreateEffect(cGenericObject* object, EffectType effectType)
    {
        bool result = false;
        switch (effectType)
        {
        case EffectType::Magnet:
            result = object->createEffectMagnetic();
            break;
        case EffectType::StickSlip:
            result = object->createEffectStickSlip();
            break;
        case EffectType::Surface:
            result = object->createEffectSurface();
            break;
        case EffectType::Vibration:
            result = object->createEffectVibration();
            break;
        case EffectType::Viscosity:
            result = object->createEffectViscosity();
            break;
        case EffectType::None:
            result = true;
            break;
        default:
            break;
        }
        return result;
    }

    void GenericObject_SetQuaternion(cGenericObject* object, Vec4 q)
    {
        //Convert quaterion to chai3d coordinate system, converting and applying it to the object
        cQuaternion cQuaternion = ConvertQuaternionToCHAI3D(q);
        cMatrix3d rotMat;
        cQuaternion.toRotMat(rotMat);
        object->setLocalRot(rotMat);
    }

    Vec4 GenericObject_GetQuaternion(cGenericObject* object)
    {
        //Convert rotation matrix of object to quaterion converted to unity coordinate system
        cQuaternion q;
        q.fromRotMat(object->getLocalTransform().getLocalRot());
        Vec4 vecQ = {
            static_cast<float>(q.x),
            static_cast<float>(q.y),
            static_cast<float>(q.z),
            static_cast<float>(q.w)
        };

        vecQ = ConvertQuaternionToUnity(vecQ);

        return vecQ;
    }

    void GenericObject_ScaleObject(cGenericObject* object, double scale)
    {
        object->scale(scale);
    }

    Transform GenericObject_GetGlobalTransform(cGenericObject* object)
    {
        cTransform globalCTrans = object->getGlobalTransform();
        return Chai3dTransformToUnityTransform(globalCTrans);
    }

    void GenericObject_SetNewTransform(cGenericObject* object, Transform worldToObject)
    {
        cTransform cWorldToObject = UnityTransformToChai3DTransform(worldToObject);

        //First get the parent to world transform for all parents
        cGenericObject* child = object;
        cGenericObject* parent = child->getParent();

        cTransform parentToWorld;
        while (parent != nullptr)
        {
            parentToWorld = parentToWorld * parent->getLocalTransform();
            child = parent;
            parent = child->getParent();
        }
        parentToWorld.invert();
        cTransform parentToObject = parentToWorld * cWorldToObject;

        object->setLocalTransform(parentToObject);
    }
    void GenericObject_DeleteAllChildren(cGenericObject* object)
    {
        object->deleteAllChildren();
    }
    
    void GenericObject_Delete(cGenericObject* object)
    {
        object->deleteAllChildren();
        delete object;
    }
}
