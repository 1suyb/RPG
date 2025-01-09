using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : EntityAnimationController
{
    [SerializeField] private string _isStun;
    [SerializeField] private string _isBattle;
    [SerializeField] private string _isAttack;
    [SerializeField] public string _attackNumber;
    [SerializeField] private string _hit;
    [SerializeField] private string _die;
    [SerializeField] private string _forward;
    [SerializeField] private string _vertical;

    private int _isStunHash;
    private int _isBattleHash;
    private int _isAttackHash;
    private int _attackNumberHash;
    private int _hitHash;
    private int _dieHash;
    private int _forwardHash;
    private int _verticalHash;

    private string _attack1Tag;
    private string _attack2Tag;

    public event Action OnAttack1EndEvent;
    public event Action OnAttack2EndEvent;

    public void OnAttack1End()
    {
        OnAttack1EndEvent?.Invoke();
    }

    public void OnAttack2End()
    {
        OnAttack2EndEvent?.Invoke();
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
    }
    public void Die()
    {
        SetTrigger(_dieHash);
    }

    public void Move(float forward, float vertical)
    {
        SetFloat(_forwardHash, forward);
        SetFloat(_verticalHash, vertical);
    }

    public float IsPlayAttack1()
    {
        return IsPlayAnimation(_attack1Tag, 0);
    }
    public float IsPlayAttack2()
    {
        return IsPlayAnimation(_attack2Tag, 0);
    }

    protected override void Awake()
    {
        base.Awake();
        _isStunHash = Animator.StringToHash(_isStun);
        _isBattleHash = Animator.StringToHash(_isBattle);
        _isAttackHash = Animator.StringToHash(_isAttack);
        _attackNumberHash = Animator.StringToHash(_attackNumber);
        _hitHash = Animator.StringToHash(_hit);
        _dieHash = Animator.StringToHash(_die);
        _forwardHash = Animator.StringToHash(_forward);
        _verticalHash = Animator.StringToHash(_vertical);
    }
}
