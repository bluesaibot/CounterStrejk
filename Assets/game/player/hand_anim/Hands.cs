using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hands : MonoBehaviour
{
    private List<InputDevice> devices = new List<InputDevice>();
    public Animator animator;
    public int isRight = 0;
    private bool isHoldingMP5 = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDeviceCharacteristics controllerCharacteristics = InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if (devices[isRight].TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            if (!isHoldingMP5)
            {
                StartCoroutine("recordGrip", gripValue);
                StopCoroutine("recordGripMP5");
                animator.SetFloat("GripMP5", 0);
            }
            if (isHoldingMP5)
            {
                StopCoroutine("recordGrip");
                StartCoroutine("recordGripMP5", gripValue);

            }
        }
    }

    public void setPoseMP5()
    {
        isHoldingMP5 = true;
    }

    public void unsetPoseMP5()
    {
        isHoldingMP5 = false;
    }

    IEnumerator recordGripMP5(float gripValue)
    {
        animator.SetFloat("GripMP5", gripValue);
        yield return null;
    }

    IEnumerator recordGrip(float gripValue)
    {
        animator.SetFloat("Grip", gripValue);
        yield return null;
    }
}
