using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TeleportationManager : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public GameObject rayInteractor;

    private InputDevice targetDevice;
    private const float triggerDeadzone = 0.1f;

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }

        rayInteractor.SetActive(false);
    }

    void Update()
    {
        if (!targetDevice.isValid)
            TryInitialize();
        else
        {
            CheckInput();
        }
        
    }

    // Active teleport on button down, else deactivate
    void CheckInput()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > triggerDeadzone)
        {
            rayInteractor.SetActive(true);
        }
        else
        {
            rayInteractor.SetActive(false);
        }
    }
}
