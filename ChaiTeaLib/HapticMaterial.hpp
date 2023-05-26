#pragma once
#define DllExport __declspec( dllexport )

#include "Types.hpp"
#include "chai3d.h"


#ifdef __cplusplus
extern "C" {
#endif
	DllExport chai3d::cMaterial* HapticMaterial_Create();

	//Set haptic properties of the material. Thiscall invocation style
	DllExport bool HapticMaterial_SetStiffness(chai3d::cMaterial* material, double stiffness);
	DllExport bool HapticMaterial_SetDamping(chai3d::cMaterial* material, double damping);
	DllExport bool HapticMaterial_SetViscosity(chai3d::cMaterial* material, double viscosity);
	
	DllExport bool HapticMaterial_SetStaticFriction(chai3d::cMaterial* material, double staticFriction);
	DllExport bool HapticMaterial_SetDynamicFriction(chai3d::cMaterial* material, double dynamicFriction);

	DllExport bool HapticMaterial_SetVibrationFrequency(chai3d::cMaterial* material, double frequency);
	DllExport bool HapticMaterial_SetVibrationAmplitude(chai3d::cMaterial* material, double amplitude);

	DllExport bool HapticMaterial_SetMagnetMaxForce(chai3d::cMaterial* material, double maxForce);
	DllExport bool HapticMaterial_SetMagnetMaxDistance(chai3d::cMaterial* material, double maxDistance);

	DllExport bool HapticMaterial_SetStickSlipForceMax(chai3d::cMaterial* material, double stickSlipForceMax);
	DllExport bool HapticMaterial_SetStickSlipStiffness(chai3d::cMaterial* material, double stickSlipStiffness);

	DllExport void HapticMaterial_SetHapticTriangleSides(chai3d::cMaterial* material, bool frontside, bool backside);

#ifdef __cplusplus
}
#endif
