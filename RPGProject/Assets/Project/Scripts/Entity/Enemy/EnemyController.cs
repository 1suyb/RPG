using UnityEngine;

public class EnemyController : EntityController
{
    [SerializeField] protected EnemyAnimationController _animationController;
    [SerializeField] protected Transform _target;
    [SerializeField] protected float _attackRange;

    private bool _isAttacking;
    private bool _isAttackEnd;
    private bool _isStun;
    private bool _isStunning;
    private bool _isStunEnd;
    private bool _isHit;
    private bool _isHitting;
    private bool _isHitEnd;
    
    public override void Load()
    {
        base.Load();
        var _animationEventReceiver = gameObject.GetComponentInDirectChild<EnemyAnimationEventReceiver>();
        _animationEventReceiver.OnEndAttackEvent += () => { _isAttackEnd = true; };
    }

    public override void Init()
    {
        base.Init();
        _isAttacking = false;
        _isAttackEnd = false;
        _isStun = false;
        _isStunning = false;
        _isStunEnd = false;
        _isHit = false;
        _isHitting = false;
        _isHitEnd = false;
    }

    public void Toward(Transform transform, float speed)
    { 
        Vector3 targetPosition = transform.position;
        Vector3 moveDir = (targetPosition - this.transform.position).normalized;
        
        Move(moveDir, speed);
        LookAt(new Vector2(targetPosition.x,targetPosition.z));
    }

    public bool IsTargetInRange()
    {
        if (_isAttacking)
        {
            return true;
        }
        return this.transform.Distance(_target) < _attackRange;
    }
    
    public NodeState Attack()
    {
        if (_isAttackEnd)
        {
            _isAttacking = false;
            _isAttackEnd = false;
            _animationController.StopAttack();
            return NodeState.Success;
        }
        if (_isAttacking)
        {
            return NodeState.Running;
        }
        else
        {
            Vector3 targetPosition = transform.position;
            LookAt(new Vector2(targetPosition.x,targetPosition.z));
            _isAttacking = true;
            int attackIndex =  RandomAttackSelect();
            _animationController.Attack(attackIndex);
            return NodeState.Running;
        }
    }

    protected int RandomAttackSelect(int attackCount = 2)
    {
        return Random.Range(0, attackCount);
    }
    
    public NodeState Chase()
    {
        Toward(_target,1f);
        return NodeState.Success;
    }

    public NodeState Stun()
    {
        if (_isStunEnd)
        {
            _isStunEnd = false;
            _isStun = false;
            _isStunning = false;
            _animationController.StopStun();
            return NodeState.Success;
        }
        if (_isStunning)
        {
            return NodeState.Running;
        }
        if (_isStun)
        {
            _isStunning = true;
            _animationController.Stun();
            return NodeState.Running;
        }
        return NodeState.Failure;
    }

    public NodeState Hit()
    {
        if (_isHitEnd)
        {
            _isHitEnd = false;
            _isHitting = false;
            _isHit = false;
            return NodeState.Success;
        }
        if (_isHitting)
        {
            return NodeState.Running;
        }
        if (_isHit)
        {
            _isHit = false;
            _animationController.Hit();
            return NodeState.Running;
        }
        return NodeState.Failure;
    }
    
    
    
}
