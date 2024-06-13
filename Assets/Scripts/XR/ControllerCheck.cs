using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ControllerCheck : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;

    void OnEnable()
    {
        InputDevices.deviceConnected += OnDeviceConnected;
        InputDevices.deviceDisconnected += OnDeviceDisconnected;
        CheckVRControllers();
    }

    void OnDisable()
    {
        InputDevices.deviceConnected -= OnDeviceConnected;
        InputDevices.deviceDisconnected -= OnDeviceDisconnected;
    }

    void OnDeviceConnected(InputDevice device)
    {
        CheckVRControllers();
    }

    void OnDeviceDisconnected(InputDevice device)
    {
        CheckVRControllers();
    }

    void CheckVRControllers()
    {
        var devices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(devices);

        bool leftControllerDetected = false;
        bool rightControllerDetected = false;

        foreach (var device in devices)
        {
            if (device.characteristics.HasFlag(InputDeviceCharacteristics.Left))
            {
                leftControllerDetected = true;
            }
            else if (device.characteristics.HasFlag(InputDeviceCharacteristics.Right))
            {
                rightControllerDetected = true;
            }
        }

        leftHand.SetActive(leftControllerDetected);
        rightHand.SetActive(rightControllerDetected);
    }

}
