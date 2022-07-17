using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonCameraControl : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _vcamPOV, _vcamOrbital;   //Populate inspector

    private void Start()
    {
        _vcamPOV.Priority = 15;                                //POV Camera needs highest priority
        _vcamOrbital.Priority = 10;
    }

    private void Update()
    {
        CameraSwitch();
    }

    private void CameraSwitch()
    {
        if (Input.GetMouseButton(1))                            //On RMB down
        {
            _vcamOrbital.Priority = 20;                         //Switch to orbital
        }
        else _vcamOrbital.Priority = 10;
    }
}
