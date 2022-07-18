using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private CinemachineImpulseSource _gunShotImpulse;

    private void Start()
    {
        _gunShotImpulse = GetComponentInChildren<CinemachineImpulseSource>();
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetMouseButton(0))
        {
            FireGun();
        }
    }

    private void FireGun()
    {
        //Gun logic and bullet etc

        _gunShotImpulse.GenerateImpulse();
    }
}
