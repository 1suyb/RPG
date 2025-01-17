using UnityEngine;

public class DefenceEnemyAnimationController : EnemyAnimationController
{
    private string _isDefence = "IsDefence";
    private int _isDefenceHash;

    public void Defence()
    {
        SetBool(_isDefenceHash, true);
    }
    public void StopDefence()
    {
        SetBool(_isDefenceHash, false);
    }
    protected override void Awake()
    {
        base.Awake();
        _isDefenceHash = Animator.StringToHash(_isDefence);
    }
}