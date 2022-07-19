using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private CinemachineImpulseSource _gunShotImpulse;
    private Animator _anim;

    private void Start()
    {
        _gunShotImpulse = GetComponentInChildren<CinemachineImpulseSource>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetMouseButton(1))
        {
            AimGun();
        }
        else Holster();

        if (Input.GetMouseButton(0))
        {
            FireGun();
        }
    }

    private void AimGun()
    {
        _anim.SetBool("Aiming", true);
    }

    private void Holster()
    {
        _anim.SetBool("Aiming", false);
    }

    private void FireGun()
    {
        //Gun logic and bullet etc

        _gunShotImpulse.GenerateImpulse();
    }
}
