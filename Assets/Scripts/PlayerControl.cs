using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private float _rotateSpeed;

    private Vector3 _direction;
    private Vector3 _rotation;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();

        if (_controller == null)
        {
            Debug.LogError("Character Controller NULL!");
        }
    }

    private void Update()
    {
        CalculateMovement();
        CalculateRotation();
    }

    private void CalculateMovement()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        Vector3 _movement = _direction * _movementSpeed * Time.deltaTime;

        Move(_movement);
    }

    private void Move(Vector3 movement)
    {
        _controller.Move(movement);
    }

    private void CalculateRotation()
    {
        _rotation.y = Input.GetAxis("Mouse X");

        transform.Rotate(_rotation * _rotateSpeed * Time.deltaTime);
    }
}
