#pragma once

#include "Simulation.hpp"
#include "HapticMaterial.hpp"
#include "Util.hpp"
#include <strstream>

extern "C" {
    cMaterial* HapticMaterial_Create()
    {
        return new cMaterial();
    }

    bool HapticMaterial_SetStiffness(cMaterial* material, double stiffness)
    {
        if (material == nullptr)
            return false;
        material->setStiffness(stiffness);
        return true;
    }

    bool HapticMaterial_SetDamping(cMaterial* material, double damping)
    {
        if (material == nullptr)
            return false;
        material->setDamping(damping);
        return true;
    }

    bool HapticMaterial_SetViscosity(cMaterial* material, double viscosity)
    {
        if (material == nullptr)
            return false;
        material->setViscosity(viscosity);
        return true;
    }

    bool HapticMaterial_SetStaticFriction(cMaterial* material, double staticFriction)
    {
        if (material == nullptr)
            return false;
        material->setStaticFriction(staticFriction);
        return true;
    }

    bool HapticMaterial_SetDynamicFriction(cMaterial* material, double dynamicFriction)
    {
        if (material == nullptr)
            return false;
        material->setDynamicFriction(dynamicFriction);
        return true;
    }

    bool HapticMaterial_SetVibrationFrequency(cMaterial* material, double frequency)
    {
        if (material == nullptr)
            return false;
        material->setVibrationFrequency(frequency);
        return true;
    }

    bool HapticMaterial_SetVibrationAmplitude(cMaterial* material, double amplitude)
    {
        if (material == nullptr)
            return false;
        material->setVibrationAmplitude(amplitude);
        return true;
    }

    bool HapticMaterial_SetMagnetMaxForce(cMaterial* material, double maxForce)
    {
        if (material == nullptr)
            return false;
        material->setMagnetMaxForce(maxForce);
        return true;
    }

    bool HapticMaterial_SetMagnetMaxDistance(cMaterial* material, double maxDistance)
    {
        if (material == nullptr)
            return false;
        material->setMagnetMaxDistance(maxDistance);
        return true;
    }

    bool HapticMaterial_SetStickSlipForceMax(cMaterial* material, double stickSlipForceMax)
    {
        if (material == nullptr)
            return false;
        material->setStickSlipForceMax(stickSlipForceMax);
        return true;
    }

    bool HapticMaterial_SetStickSlipStiffness(cMaterial* material, double stickSlipStiffness)
    {
        if (material == nullptr)
            return false;
        material->setStickSlipStiffness(stickSlipStiffness);
        return true;
    }
    void HapticMaterial_SetHapticTriangleSides(cMaterial* material, bool frontside, bool backside)
    {
        if (material == nullptr)
        {
            UnityDebug_Log("Attempting to set haptic triangles on nullptr");
        }
        return material->setHapticTriangleSides(frontside, backside);
    }
}





