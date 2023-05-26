#include "Shapes.hpp"
#include "Util.hpp"

using namespace chai3d;

extern "C" {
    chai3d::cShapeSphere* ShapeSphere_Create(double radius)
    {
        return new cShapeSphere(radius);
    }

    chai3d::cShapeBox* ShapeBox_Create(Vec3 size)
    {
        cVector3d cSize = ConvertXYZToCHAI3D(size);

        return new cShapeBox(cSize.x(), cSize.y(), cSize.z());
    }


    chai3d::cShapeCylinder* ShapeCylinder_Create(double baseRadius, double topRadius, double height)
    {
        return new cShapeCylinder(baseRadius, topRadius, height);
    }
}