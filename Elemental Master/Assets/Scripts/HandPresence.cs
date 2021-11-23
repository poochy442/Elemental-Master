using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{

    public InputDeviceCharacteristics controllerCharacteristics;
    public GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject spawnedHandModel;
    private Animator handAnimator;
    private const float triggerDeadzone = 0.1f;
    
    void Start()
    {
        TryInitialize();
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            spawnedHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
    }

    void UpdateAnimation()
    {
        // Trigger - Teleport
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > triggerDeadzone)
            handAnimator.SetFloat("Teleport", triggerValue);
        else
            handAnimator.SetFloat("Teleport", 0);

        // Grip - Grip spell
        /*if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > triggerDeadzone)
            handAnimator.SetFloat("Grip", gripValue);
        else
            handAnimator.SetFloat("Grip", 0); */

        // TODO: Local spell + cast spell
        if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
            handAnimator.SetBool("CastSpell", primaryButtonValue);
        else
            handAnimator.SetBool("CastSpell", false);
    }
    
    void Update()
    {
        if (!targetDevice.isValid)
            TryInitialize();
        else
        {
            UpdateAnimation();
        }
    }
}
