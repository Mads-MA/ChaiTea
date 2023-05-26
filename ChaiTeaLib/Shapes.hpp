#pragma once
#define DllExport   __declspec( dllexport )


#include "chai3d.h"
#include "Types.hpp"


#ifdef __cplusplus
extern "C" {
#endif
	DllExport chai3d::cShapeSphere* ShapeSphere_Create(double radius);
	DllExport chai3d::cShapeBox* ShapeBox_Create(Vec3 size);
	DllExport chai3d::cShapeCylinder* ShapeCylinder_Create(double baseRadius, double topRadius, double height);
#ifdef __cplusplus
}
#endif