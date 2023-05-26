#pragma once
#include <cstdint>
#include "chai3d.h"


#ifdef __cplusplus
extern "C" {
#endif

struct Vec3{
	float x;
	float y;
	float z;
};

struct Vec4
{
	float x;
	float y;
	float z;
	float w;
};

struct Transform
{
	Vec3 position;
	Vec4 rotation;
	//Vec3 scale; cTransform does not contain type like the unity transform does
};


enum class EffectType : int32_t {
	None = 0,
	Magnet = 1,
	StickSlip = 1 << 1,
	Surface = 1 << 2,
	Vibration = 1 << 3,
	Viscosity = 1 << 4
};


#ifdef __cplusplus
}
#endif



Transform Chai3dTransformToUnityTransform(chai3d::cTransform cTrans);
chai3d::cTransform UnityTransformToChai3DTransform(Transform trans);