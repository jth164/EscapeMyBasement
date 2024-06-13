using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR;

public class ControllerDebug : MonoBehaviour
{
    // Define all buttons you want to check
    private List<InputFeatureUsage<bool>> buttons = new List<InputFeatureUsage<bool>>
    {
        CommonUsages.triggerButton,
        CommonUsages.gripButton,
        CommonUsages.primaryButton,
        CommonUsages.secondaryButton,
        CommonUsages.menuButton,
        CommonUsages.primary2DAxisClick,
        CommonUsages.secondary2DAxisClick
    };

    void Update()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Controller, devices);

        foreach (var device in devices)
        {
            foreach (var button in buttons)
            {
                if (device.TryGetFeatureValue(button, out bool pressed) && pressed)
                {
                    Debug.Log(device.name + " " + button.name + " Pressed");
                }
            }
        }
    }
}
