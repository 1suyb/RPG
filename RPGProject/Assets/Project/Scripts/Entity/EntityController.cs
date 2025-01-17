using System;
using UnityEngine;
using UnityEngine.Serialization;

public class EntityController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _groundDistance;
    [SerializeField] private float _speed;
    private Vector3 _dampingVelocity;
    private float _verticalSpeed;
    private Vector3 _impact;
    
    private Vector3 _physicalMove => _impact + _verticalSpeed* Vector3.up;
    //public bool IsGrounded => _characterController.isGrounded;
    public bool IsAriUp => _verticalSpeed > 0;

    public bool IsGrounded =>Physics.CheckSphere(this.transform.position, _groundDistance, _groundMask);
   
    protected virtual void Awake()
    {
        Load();
        InitOnActivate();
    }

    public virtual void Load()
    {
        if(_characterController == null)
            _characterController = GetComponent<CharacterController>();
    }

    public virtual void InitOnActivate()
    {
        _dampingVelocity = new Vector3(0,0,0);
        _impact = new Vector3(0,0,0);
    }

    private void Update()
    {
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
        _characterController.Move(( speed * _speed * dir + _physicalMove)* Time.deltaTime);
    }
    
    public void LookAt(Vector2 lookDir)
    {
        Quaternion lookRotation = RotateVector(lookDir);
        transform.rotation = Quaternion.Lerp(this.transform.rotation, lookRotation, 1f);
    }

    public static Quaternion RotateVector(Vector2 lookDir)
    {
        return Quaternion.Euler(0, Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg, 0);
    }
}
