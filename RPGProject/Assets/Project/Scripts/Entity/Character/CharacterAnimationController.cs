using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : EntityAnimationController
{
    private string _isMove = "IsMove";
    private string _isJump = "IsJump";
    private string _isFall = "IsFall";
    private string _isStun = "IsStun";
    private string _hit = "Hit";
    private string _dodge = "Dodge";
    private string _potion = "Potion";
    private string _pickUp = "PickUp";
    private string _forward = "Forward";
    private string _vertical = "Vertical";
    private string _isEquipped = "IsEquipped";
    private string _equipChange = "EquipChange";
    private string _isAttack = "IsAttack";
    private string _isCharging = "IsCharging";
    private string _attackNum = "AttackNum";
    private string _isClimb = "IsClimb";
    private string _isDie = "IsDie";
    private string _die = "Die";

    private int _isMoveHash;
    private int _isJumpHash;
    private int _isFallHash;
    private int _isStunHash;
    private int _hitHash;
    private int _dodgeHash;
    private int _potionHash;
    private int _pickUpHash;
    private int _forwardHash;
    private int _verticalHash;
    private int _isEquippedHash;
    private int _equipChangeHash;
    private int _isAttackHash;
    private int _isChargingHash;
    private int _attackNumHash;
    private int _isClimbHash;
    private int _isDieHash;
    private int _dieHash;

    public string JumpStartTag { get; private set; } = "JumpStart";
    public string JumpEndTag { get; private set; } = "JumpEnd";
    public string DodgeTag { get; private set; } = "Dodge";
    public string EquipChangeTag { get; private set; } = "EquipChange";
    public string AttackTag { get; private set; } = "Attack";
    
    protected override void Awake()
    {
        base.Awake();
        _isMoveHash = Animator.StringToHash(_isMove);
        _isJumpHash = Animator.StringToHash(_isJump);
        _isFallHash = Animator.StringToHash(_isFall);
        _isStunHash = Animator.StringToHash(_isStun);
        _hitHash = Animator.StringToHash(_hit);
        _dodgeHash = Animator.StringToHash(_dodge);
        _potionHash = Animator.StringToHash(_potion);
        _pickUpHash = Animator.StringToHash(_pickUp);
        _forwardHash = Animator.StringToHash(_forward);
        _verticalHash = Animator.StringToHash(_vertical);
        _isEquippedHash = Animator.StringToHash(_isEquipped);
        _equipChangeHash = Animator.StringToHash(_equipChange);
        _isAttackHash = Animator.StringToHash(_isAttack);
        _isChargingHash = Animator.StringToHash(_isCharging);
        _attackNumHash = Animator.StringToHash(_attackNum);
        _isClimbHash = Animator.StringToHash(_isClimb);
        _isDieHash = Animator.StringToHash(_isDie);
        _dieHash = Animator.StringToHash(_die);
    }

    #region Move
    public void StartMove()
    {
        SetBool(_isMoveHash, true);
    }
    public void StopMove()
    {
        SetBool(_isMoveHash, false);
    }
    public void SetMoveDir(float forward, float vertical)
    {
        SetFloat(_forwardHash, forward);
        SetFloat(_verticalHash, vertical);
    }
    #endregion

    #region Jump
    public void StartJump()
    {
        SetBool(_isJumpHash, true);
    }
    public void StopJump()
    {
        SetBool(_isJumpHash, false);
    }
    public void StartFall()
    {
        SetBool(_isFallHash, true);
    }
    public void StopFall()
    {
        SetBool(_isFallHash, false);
    }
    #endregion

    #region Attack
    
    public void StartAttack(int number)
    {
        if(GetBool(_isMoveHash))
            SetLayerWeight(1,1);
        SetInt(_attackNumHash, number);
        SetBool(_isAttackHash, true);
    }
    public void StopAttack()
    {
        SetLayerWeight(1,0);
        SetBool(_isAttackHash, false);
    }
    
    public void StartCharging()
    {
        SetBool(_isChargingHash, true);
    }
    public void StopCharging()
    {
        SetBool(_isChargingHash, false);
    }

    #endregion
    
    #region Hit
    public void Hit()
    {
        SetTrigger(_hitHash);
    }

    public void Stun()
    {
        SetBool(_isStunHash, true);
        SetTrigger(_hitHash);
    }
    
    public void StopStun()
    {
        SetBool(_isStunHash, false);
    }
    #endregion

    #region Die
    public void Die()
    {
        SetBool(_isDieHash, true);
        SetTrigger(_dieHash);
    }

    public void Resurrection()
    {
        SetBool(_isDieHash, false);
    }
    #endregion

    #region Climb
    public void Climb()
    {
        SetBool(_isClimbHash, true);
    }
    public void StopClimb()
    {
        SetBool(_isClimbHash, false);
    }
    #endregion

    #region Actions
    public void Dodge()
    {
        SetTrigger(_dodgeHash);
    }
    public void Potion()
    {
        SetTrigger(_potionHash);
    }
    public void PickUp()
    {
        SetTrigger(_pickUpHash);
    }
    #endregion

    #region Equpment
    public void Equip(bool isEquip)
    {
        SetBool(_isEquippedHash, isEquip);
        SetTrigger(_equipChangeHash);
        
    }
    public void UnEquip()
    {
        SetBool(_isEquippedHash, false);
        SetTrigger(_equipChangeHash);
    }
    #endregion
    
}
