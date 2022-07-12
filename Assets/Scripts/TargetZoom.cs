using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetZoom : MonoBehaviour
{
    private CinemachineVirtualCamera _vCam;
    
    [SerializeField]
    private GameObject[] _objectsToTrack;

    [SerializeField]
    private float[] _fieldOfViewValues;

    private void Start()
    {
        _vCam = GetComponent<CinemachineVirtualCamera>();

        if (_vCam == null)
        {
            Debug.LogError("Virtual Camera not attached");
        }
        else
        {
            _vCam.LookAt = _objectsToTrack[0].transform;
            _vCam.m_Lens.FieldOfView = _fieldOfViewValues[0];
        }
    }

    private void Update()
    {
        TrackingCycler();
        FOVCycler();
    }

    private void TrackingCycler()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject CurrentTarget = _vCam.LookAt.gameObject;

            for (int i = 0; i < _objectsToTrack.Length; i++)                //Cycles through array
            {
                if (_objectsToTrack[i] == CurrentTarget)                    //On finding the current target
                {
                    if (i >= _objectsToTrack.Length - 1)                    //Check if end of array
                    {               
                        TargetSwitch(_objectsToTrack[0].transform);         //And reset to 0
                        break;
                    }
                    else TargetSwitch(_objectsToTrack[i + 1].transform);    //Otherwise, cycle to next target
                    break;
                }
            }
        }
    }

    private void TargetSwitch(Transform Target)
    {
        _vCam.LookAt = Target;
    }

    private void FOVCycler()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float _fieldOfView = _vCam.m_Lens.FieldOfView;

            for (int i = 0; i < _fieldOfViewValues.Length; i++)             //Cycles through array
            {
                if (_fieldOfViewValues[i] == _fieldOfView)                  //On finding current FOV
                {
                    if (i >= _fieldOfViewValues.Length - 1)                 //Check if end of array
                    {
                        FOVSwitch((int)_fieldOfViewValues[0]);              //And reset to 0
                        break;
                    }
                    else FOVSwitch((int)_fieldOfViewValues[i + 1]);         //Otherwise, cycle to next value
                }
            }
        }
    }

    private void FOVSwitch(int value)
    {
        _vCam.m_Lens.FieldOfView = value;
    }
}
