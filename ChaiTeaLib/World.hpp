#pragma once
#define DllExport   __declspec( dllexport )


#include "chai3d.h"
#include "Types.hpp"
#include <vector>

#ifdef __cplusplus
extern "C" {
#endif
	DllExport chai3d::cWorld* World_Create();
	DllExport void World_ComputeGlobalPositions(chai3d::cWorld* pWorld, bool frameOnly);

#ifdef __cplusplus
}
#endif