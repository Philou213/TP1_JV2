using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook cinemachineCamera;
    private const float gamepadMaxSpeedY = 2f;
    private const float gamepadAccelerationTime = 0.2f;
    private const float gamepadMaxSpeedX = 200f;
    private const string gamepadX = "Gamepad Look Horizontal";
    private const string gamepadY = "Gamepad Look Vertical";

    private const float keyboardMaxSpeedY = 4f;
    private const float keyboardAccelerationTime = 0.4f;
    private const float keyboardMaxSpeedX = 600f;
    private const string mouseX = "Mouse X";
    private const string mouseY = "Mouse Y";


    public void SetCameraSettings(bool gamepadUse)
    {
        if (gamepadUse)
        {
            cinemachineCamera.m_YAxis.m_MaxSpeed = gamepadMaxSpeedY;
            cinemachineCamera.m_YAxis.m_AccelTime = gamepadAccelerationTime;
            cinemachineCamera.m_XAxis.m_MaxSpeed = gamepadMaxSpeedX;
            cinemachineCamera.m_XAxis.m_InputAxisName = gamepadX;
            cinemachineCamera.m_YAxis.m_InputAxisName = gamepadY;
        }
        else
        {
            cinemachineCamera.m_YAxis.m_MaxSpeed = keyboardMaxSpeedY;
            cinemachineCamera.m_YAxis.m_AccelTime = keyboardAccelerationTime;
            cinemachineCamera.m_XAxis.m_MaxSpeed = keyboardMaxSpeedX;
            cinemachineCamera.m_XAxis.m_InputAxisName = mouseX;
            cinemachineCamera.m_YAxis.m_InputAxisName = mouseY;
        }
    }
}
