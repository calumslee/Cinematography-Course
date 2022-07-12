using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera[] _vCams;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _vCams[0].enabled = false;
            _vCams[1].enabled = false;
        }
    }
}
