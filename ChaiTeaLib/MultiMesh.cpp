#include "MultiMesh.hpp"
#include "Util.hpp"
using namespace chai3d;
extern "C" {

	cMultiMesh* MultiMesh_Create()
	{
		UnityDebug_Log("Created multi mesh");
		return new cMultiMesh();
	}

	void MultiMesh_UseCulling(cMultiMesh* self, bool useCulling, bool affectChildren)
	{
		if (self != nullptr)
		{
			self->setUseCulling(useCulling, affectChildren);
		}
		else
		{
			UnityDebug_Log("Attempted to SetUseCulling on nullptr instead of multimesh*");
		}
	}

	void MultiMesh_CreateAABBCollisionDetector(cMultiMesh* self, double radius)
	{
		if (self != nullptr)
		{
			self->createAABBCollisionDetector(radius);
		}
		else
		{
			UnityDebug_Log("Attempted to Create AABB Collision Detector on nullptr instead of multimesh*");
		}
	}

	cMesh* MultiMesh_NewMesh(cMultiMesh* self)
	{
		if (self != nullptr)
			return self->newMesh();
		else
		{
			UnityDebug_Log("Attempted to create new mesh on nullptr instead of multimesh");
			return nullptr;
		}
	}

	void MultiMesh_AddMesh(cMultiMesh* self, cMesh* mesh)
	{
		if (self != nullptr)
		{
			if (mesh != nullptr)
				self->addMesh(mesh);
			else
				UnityDebug_Log("Tried to add mesh to multimesh, but the mesh was nullptr");
		}
		else
			UnityDebug_Log("Tried to add mesh to multimesh, but multimesh was nullptr");
	}

	void MultiMesh_RemoveMesh(cMultiMesh* self, cMesh* mesh)
	{
		if (self != nullptr)
		{
			if (mesh != nullptr)
				self->removeMesh(mesh);
			else
				UnityDebug_Log("Tried to remove mesh from multimesh, but mesh was nullptr");
		}
		else
			UnityDebug_Log("Tried to remove mesh from multimesh, but multimesh was nullptr");
	}



}
