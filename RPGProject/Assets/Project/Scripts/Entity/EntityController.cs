using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundDistance;
    private Vector3 _dampingVelocity;
    private float _verticalSpeed;
    private Vector3 _impact;
    
    private Vector3 _physicalMove => _impact + _verticalSpeed* Vector3.up;
    //public bool IsGrounded => _characterController.isGrounded;
    public bool IsAriUp => _verticalSpeed > 0;

    public bool IsGrounded
    {
        get
        {
            return Physics.CheckSphere(this.transform.position, groundDistance, groundMask);
        }
    }
    
    private void Awake()
    {
        if(_characterController == null)
            _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Debug.Log(IsGrounded ? "Grounded" : "Not Grounded");
        if(IsGrounded && _verticalSpeed < 0)
        {
            _verticalSpeed = -_gravity * Time.deltaTime;
        }
        else
        {
            _verticalSpeed -= _gravity * Time.deltaTime;
        }
        
        _impact = Vector3.SmoothDamp(_impact, Vector3.zero, ref _dampingVelocity, 0.1f);
    }

    public void Jump(float jumpForce)
    {
        _verticalSpeed = jumpForce*_gravity;
    }

    public void AddForce(Vector3 force)
    {
        _impact += force;
    }

    public void Move(Vector3 dir, float speed)
    {
        Vector3 moveDir = transform.forward * dir.z + transform.right * dir.x;
        Debug.Log((dir * speed + _physicalMove)* Time.deltaTime);
        _characterController.Move((dir * speed + _physicalMove)* Time.deltaTime);
    }
    
    public void LookAt(Vector2 lookDir)
    {
        Quaternion lookRotation = RorateVector(lookDir);
        transform.rotation = Quaternion.Lerp(this.transform.rotation, lookRotation, 1f);
    }

    public static Quaternion RorateVector(Vector2 lookDir)
    {
        return Quaternion.Euler(0, Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg, 0);
    }
}
