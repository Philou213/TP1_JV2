using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public bool gamepadUse = false;
    private float timeBeforeCheck = 5;
    private CameraManager cameraManager;
    // Start is called before the first frame update
    void Start()
    {
        cameraManager = GetComponent<CameraManager>();
        StartCoroutine("CheckForGamepad");
    }

    IEnumerator CheckForGamepad()
    {
        while (true)
        {
            bool oldInput = gamepadUse;
            if (Input.GetJoystickNames().Length > 0)
            {
                gamepadUse = Input.GetJoystickNames()[0].Length > 0;
                if (oldInput != gamepadUse) 
                {
                    cameraManager.SetCameraSettings(gamepadUse);
                }
            }
            yield return new WaitForSeconds(timeBeforeCheck);
        }
    }
}
