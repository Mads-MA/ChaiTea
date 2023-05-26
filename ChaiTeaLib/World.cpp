#include "World.hpp"

chai3d::cWorld* World_Create()
{
    return new chai3d::cWorld();
}

void World_ComputeGlobalPositions(chai3d::cWorld* pWorld, bool frameOnly)
{
    pWorld->computeGlobalPositions(frameOnly);
}
