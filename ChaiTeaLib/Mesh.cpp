#pragma once
#include "Mesh.hpp"
#include "Util.hpp"

extern "C" {

	//Creates empty mesh object for further use
	cMesh* Mesh_Create()
	{
		return new cMesh();
	}

	//Uses a Unity mesh to generate a mesh in chai3D
	void Mesh_FromUnityMesh(cMesh* mesh, Vec3* vertices, int vertCount, Vec3* normals, int normalCount, int* triangles, int trisCount)
	{
		//Set normals and vertices of the mesh
		for (size_t i = 0; i < trisCount / 3; i++)
		{
			int indexV1 = mesh->newVertex(ConvertXYZToCHAI3D(vertices[triangles[3*i+2]]));
			int indexV2 = mesh->newVertex(ConvertXYZToCHAI3D(vertices[triangles[3*i+1]]));
			int indexV3 = mesh->newVertex(ConvertXYZToCHAI3D(vertices[triangles[3*i+0]]));

			unsigned int indexTriangle = mesh->newTriangle(indexV1, indexV2, indexV3);

			mesh->m_triangles->computeNormal(indexTriangle, true);
		}

		//mesh->computeAllNormals();
		mesh->setUseMaterial(true);
		mesh->computeBoundaryBox(true);
	}

	//Creates a plane with given dimension
	void Mesh_CreatePlane(cMesh* mesh, double lengthX, double lengthY)
	{
		cCreatePlane(mesh, lengthX, lengthY);
	}

	//Builds collision detector for given mesh
	void Mesh_CreateAABBCollisionDetector(cMesh* mesh, double toolRadius)
	{
		mesh->createAABBCollisionDetector(toolRadius);
	}

	//Scale mesh by XYZ. Applying multiple scales will not override precious, so it is equivalent to saying
	//scale1*scale2*scale3 etc.
	void Mesh_ScaleXYZ(cMesh* mesh, Vec3 scale)
	{
		cVector3d cScaleNotAbs = ConvertXYZToCHAI3D(scale);
		double x = cAbs(cScaleNotAbs.x());
		double y = cAbs(cScaleNotAbs.y());
		double z = cAbs(cScaleNotAbs.z());

		mesh->scaleXYZ(x, y, z);
	}
}
