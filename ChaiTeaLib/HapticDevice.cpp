#include "HapticDevice.hpp"
#include "Types.hpp"
#include "Util.hpp"

cHapticDeviceHandler* deviceHandler = nullptr;


bool HapticDevice_GetDevice(cGenericHapticDevicePtr& devicePtr, int deviceIndex, bool allowVirtualDevice)
{
	if (deviceHandler == nullptr)
	{
		deviceHandler = new cHapticDeviceHandler();
	}

	//Return device through parameter. Return false if it false otherwise true.
	bool gotVirtualDevice = deviceHandler->getDevice(devicePtr, deviceIndex);
	if (gotVirtualDevice == true && allowVirtualDevice == false)
		return false;

	return true;
}

cHapticDeviceInfo HapticDevice_GetInfo(int deviceIndex)
{
	if (deviceHandler == nullptr)
	{
		deviceHandler = new cHapticDeviceHandler();
	}

	cGenericHapticDevicePtr device;
	deviceHandler->getDevice(device, deviceIndex);

	return device->getSpecifications();
}






extern "C" {

	HapticDeviceInfo HapticDevice_CreateInfo(cHapticDeviceInfo info)
	{
		HapticDeviceInfo newinfo;
		newinfo.m_model = info.m_model;
		newinfo.m_modelName = info.m_modelName.c_str();
		newinfo.m_manufacturerName = info.m_manufacturerName.c_str();

		newinfo.m_maxLinearForce = info.m_maxLinearForce;
		newinfo.m_maxAngularTorque = info.m_maxAngularTorque;
		newinfo.m_maxGripperForce = info.m_maxGripperForce;

		newinfo.m_maxLinearStiffness = info.m_maxLinearStiffness;
		newinfo.m_maxAngularStiffness = info.m_maxAngularStiffness;
		newinfo.m_maxGripperLinearStiffness = info.m_maxGripperLinearStiffness;

		newinfo.m_maxLinearDamping = info.m_maxLinearDamping;
		newinfo.m_maxAngularDamping = info.m_maxAngularDamping;
		newinfo.m_maxGripperAngularDamping = info.m_maxGripperAngularDamping;

		newinfo.m_workspaceRadius = info.m_workspaceRadius;

		newinfo.m_gripperMaxAngleRad = info.m_gripperMaxAngleRad;

		newinfo.m_sensedPosition = info.m_sensedPosition;
		newinfo.m_sensedRotation = info.m_sensedRotation;
		newinfo.m_sensedGripper = info.m_sensedGripper;

		newinfo.m_actuatedPosition = info.m_actuatedPosition;
		newinfo.m_actuatedRotation = info.m_actuatedRotation;
		newinfo.m_actuatedGripper = info.m_actuatedGripper;

		newinfo.m_leftHand = info.m_leftHand;
		newinfo.m_rightHand = info.m_rightHand;
		
		return newinfo;
	}
	//Open haptic device.
	bool HapticDevice_Open(int deviceIndex)
	{
		if (deviceHandler == nullptr)
		{
			deviceHandler = new cHapticDeviceHandler();
		}

		cGenericHapticDevicePtr device;
		if (!deviceHandler->getDevice(device, deviceIndex))
			return false;

		device->open();

		return true;
	}

	bool HapticDevice_Close(int deviceIndex)
	{
		if (deviceHandler == nullptr)
		{
			deviceHandler = new cHapticDeviceHandler();
		}

		cGenericHapticDevicePtr device;
		if (!deviceHandler->getDevice(device, deviceIndex))
			return false;

		device->close();

		return true;
	}

	//If device have gripper, enable them to behave like a user switch
	bool HapticDevice_SetEnableGripperUserSwitch(int deviceIndex, bool state)
	{
		if (deviceHandler == nullptr)
		{
			deviceHandler = new cHapticDeviceHandler();
		}

		cGenericHapticDevicePtr device;
		if (!deviceHandler->getDevice(device, deviceIndex))
			return false;

		device->setEnableGripperUserSwitch(state);

		return true;
	}


	//TODO Push next 3 values into a struct as pass that
	double HapticDevice_MaxLinearForce(int deviceIndex)
	{
		cHapticDeviceInfo info = HapticDevice_GetInfo(deviceIndex);
		//max exterable force specified by device or at most 7 [N]
		double maxLinearForce = info.m_maxLinearForce;
		//std::stringstream s;
		//s << "Max Linear Force " << maxLinearForce << "\n";
		//UnityDebug_Log(s.str());
		return maxLinearForce;
	}

	double HapticDevice_MaxStiffness(int deviceIndex, double workspaceScaleFactor)
	{
		cHapticDeviceInfo info = HapticDevice_GetInfo(deviceIndex);
		double maxStiffness = info.m_maxLinearStiffness / workspaceScaleFactor;
		//std::stringstream s;
		//s << "Device " << deviceIndex << ", WorkSpace Scale Factor " << workspaceScaleFactor << ",Max Stiffness " << maxStiffness << "\n";
		//UnityDebug_Log(s.str());
		return maxStiffness;
	}

	double HapticDevice_MaxDamping(int deviceIndex, double workspaceScaleFactor)
	{
		cHapticDeviceInfo info = HapticDevice_GetInfo(deviceIndex);
		double maxDamping = info.m_maxLinearDamping / workspaceScaleFactor;
		//std::stringstream s;
		//s << "Device " << deviceIndex << ", WorkSpace Scale Factor " << workspaceScaleFactor << ",Max Damping " << maxDamping << "\n";
		//UnityDebug_Log(s.str());
		return maxDamping;
	}

	HapticDeviceInfo HapticDevice_GetDeviceInfo(int deviceIndex)
	{
		return HapticDevice_CreateInfo(HapticDevice_GetInfo(deviceIndex));
	}



}


