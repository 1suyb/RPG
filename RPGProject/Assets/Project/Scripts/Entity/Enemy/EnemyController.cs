using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum EnemyState
{
    None,
    EndAnimation,
    InAnimation,
    Hit,
    Stun,
    Die,
}

public class EnemyController : EntityController
{
    [SerializeField] protected EnemyAnimationController _animationController;
    [SerializeField] protected Transform _target;
    [SerializeField] protected float _attackRange;

    protected EnemyState _state;

    private bool _isAnimationEndTrigger;
    public override void Load()
    {
        base.Load();
        var _animationEventReceiver = gameObject.GetComponentInDirectChild<EnemyAnimationEventReceiver>();
        _animationEventReceiver.OnEndAnimationEvent += () => { _state = EnemyState.EndAnimation; };
    }

    public override void Init()
    {
        base.Init();
        _state = EnemyState.None;
    }

    public void Hitted()
    {
        if (_state == EnemyState.Die || _state == EnemyState.Stun)
            return;
        _state = EnemyState.Hit;
    } 
    public void Dead()=> _state = EnemyState.Die;

    public void MoveTowardsTarget(Transform transform, float speed)
    { 
        Vector3 targetPosition = transform.position;
        Vector3 moveDir = (targetPosition - this.transform.position).normalized;
        
        Move(moveDir, speed);
        LookAt(new Vector2(targetPosition.x,targetPosition.z));
    }

    public bool IsTargetInRange()
    {
        if(_state == EnemyState.InAnimation)
            return true;
        return this.transform.Distance(_target) < _attackRange;
    }
    
    protected int RandomAttackSelect(int attackCount = 2)
    {
        return Random.Range(0, attackCount);
    }
    
    public NodeState Chase()
    {
        MoveTowardsTarget(_target,1f);
        return NodeState.Success;
    }
    
    public NodeState PerformAction(EnemyState requiredState, Action performAnimation, Action stopAnimation)
    {
        switch (_state)
        {
            case EnemyState.EndAnimation:
                _state = EnemyState.None;
                stopAnimation?.Invoke();
                return NodeState.Success;

            case EnemyState.InAnimation:
                return NodeState.Running;

            case var state when state == requiredState:
                performAnimation?.Invoke();
                _state = EnemyState.InAnimation;
                return NodeState.Running;

            default:
                return NodeState.Failure;
        }
    }
    
    public NodeState Attack()
    {
        return PerformAction(
            EnemyState.None, 
            () => _animationController.Attack(0), 
            () => _animationController.StopAttack());
    }

    public NodeState Stun()
    {
        return PerformAction(
            EnemyState.Stun, 
            () => _animationController.Stun(), 
            () => _animationController.StopStun());
    }

    public NodeState Hit()
    {
        return PerformAction(
            EnemyState.Hit, 
            () => _animationController.Hit(), 
            null);
    }
    
    public NodeState Die()
    {
        NodeState state =  PerformAction(
            EnemyState.Die, 
            () => _animationController.Die(), 
            null);
        if (state == NodeState.Success)
        {
            gameObject.SetActive(false);
        }

        return state;
    }

    public NodeState IsInAnimation(string tag)
    {
        if (_animationController.IsPlayAnimation(tag) >= 1f)
        {
            return NodeState.Success;
        }
        else
        {
            return NodeState.Running;
        }
        
    }
    
    
    
}
