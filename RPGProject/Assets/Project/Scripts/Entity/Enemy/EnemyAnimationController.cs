using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : EntityAnimationController
{
    private string _isStun = "IsStun";
    private string _isBattle = "IsBattle";
    private string _isAttack = "IsAttack";
    private string _isMove = "IsMove";
    public string _attackNumber = "AttackNumber";
    private string _hit = "Hit";
    private string _die = "Die";
    private string _forward = "Forward";
    private string _vertical = "Vertical";

    private int _isStunHash;
    private int _isBattleHash;
    private int _isAttackHash;
    private int _isMoveHash;
    private int _attackNumberHash;
    private int _hitHash;
    private int _dieHash;
    private int _forwardHash;
    private int _verticalHash;

    public string AttackTag { get; private set; } = "Attack";
    public string HitTag { get; private set; } = "Hit";
    public string DieTag { get; private set; } = "Die";
    
    public void Stun()
    {
        SetBool(_isStunHash, true);
        SetTrigger(_hitHash);
        StopAttack();
    }
    
    public void StopStun()
    {
        SetBool(_isStunHash, false);
    }
    
    public void Battle()
    {
        SetBool(_isBattleHash, true);
    }
    public void StopBattle()
    {
        SetBool(_isBattleHash, false);
    }
    public void Attack(int number)
    {
        SetInt(_attackNumberHash, number);
        SetBool(_isAttackHash, true);
    }
    public void StopAttack()
    {
        SetBool(_isAttackHash, false);
    }
    public void Hit()
    {
        SetTrigger(_hitHash);
        StopAttack();
    }
    public void Die()
    {
        SetTrigger(_dieHash);
    }

    public void Move(float forward, float vertical)
    {
        bool move = forward != 0 || vertical != 0;
        SetBool(_isMoveHash,move);
        SetFloat(_forwardHash, forward);
        SetFloat(_verticalHash, vertical);
    }
    

    protected override void Awake()
    {
        base.Awake();
        _isStunHash = Animator.StringToHash(_isStun);
        _isBattleHash = Animator.StringToHash(_isBattle);
        _isAttackHash = Animator.StringToHash(_isAttack);
        _isMoveHash = Animator.StringToHash(_isMove);
        _attackNumberHash = Animator.StringToHash(_attackNumber);
        _hitHash = Animator.StringToHash(_hit);
        _dieHash = Animator.StringToHash(_die);
        _forwardHash = Animator.StringToHash(_forward);
        _verticalHash = Animator.StringToHash(_vertical);
    }
}
