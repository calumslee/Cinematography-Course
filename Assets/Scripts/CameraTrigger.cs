using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTrigger : MonoBehaviour
{
    [Tooltip("Setup VCams under one game object")]
    [SerializeField]
    private GameObject _vcamGroup;                                                      

    [Tooltip("Cam number corresponds with the order under parent game object beginning at 0")]
    [SerializeField]
    private int _camNumber;                                                             

    private CinemachineVirtualCamera[] _vcams;                                          

    private void Start()
    {
        _vcams = _vcamGroup.GetComponentsInChildren<CinemachineVirtualCamera>();        //Dynamically populates array from group obj
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < _vcams.Length; i++)                                     //Cycle through cameras
            {
                if (i == _camNumber)                                                    //If camera matches trigger's cam no
                {
                    _vcams[i].Priority = 20;                                            //Set highest priority
                }
                else _vcams[i].Priority = 10;                                           //Otherwise restores
            }

            //Optional
            _vcams[0].Priority = 15;                                                    //Sets first camera as default
        }
    }
}
