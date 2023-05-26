#include "Types.hpp"
#include "Util.hpp"

extern "C" {


}

Transform Chai3dTransformToUnityTransform(cTransform cTrans)
{
	
	cVector3d pos = cTrans.getLocalPos();
	cQuaternion q;
	q.fromRotMat(cTrans.getLocalRot());

	Transform transform = {
		transform.position = Vec3{
			static_cast<float>(pos.x()),
			static_cast<float>(pos.y()),
			static_cast<float>(pos.z())
		},
		transform.rotation = Vec4{
			static_cast<float>(q.x),
			static_cast<float>(q.y),
			static_cast<float>(q.z),
			static_cast<float>(q.w),
		}
	};


	return transform;
}

cTransform UnityTransformToChai3DTransform(Transform trans)
{
	cVector3d position{
		 static_cast<double>(trans.position.x),
		 static_cast<double>(trans.position.y),
		 static_cast<double>(trans.position.z)
	};

	cMatrix3d rotMat;
	cQuaternion cQuaterion = ConvertQuaternionToCHAI3D(trans.rotation);
	cQuaterion.toRotMat(rotMat);

	cTransform cTrans(position, rotMat);

	return cTrans;
}