using System;
using System.Collections.Generic;
using UnityEngine;

public enum BTRunningState
{
    Wait,
    InPlay,
    End
}

[Flags]
public enum EnemyState
{
    Die = 1<<0,
    Dead = 1<<1,
    Stun = 1<<2,
    Hit = 1<<3,
    Attack = 1<<4,
    Defence = 1<<5,
    Chase = 1<<6,
    Idle = 1<<7,
}

public class EnemyAI : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] protected EnemyController _controller;
    [SerializeField] protected EnemyAnimationController _animationController;
    
    [Header("TempSettings")]
    [SerializeField] protected Transform _target;
    [SerializeField] protected float _attackRange;
    
    private BTNode _rootBtNode;
    private bool isInited = true;
    
    protected BTRunningState _nodeRunningState;
    protected EnemyState _state;
    
    public void Awake()
    {
        _rootBtNode = CreateBT();
        Load();
    }
    public void Update()
    {
        if (isInited)
        {
            _rootBtNode.Evaluate();
        }
    }
    public void Load()
    {
        var _animationEventReceiver = gameObject.GetComponentInDirectChild<EnemyAnimationEventReceiver>();
        _animationEventReceiver.OnEndAnimationEvent += () => { _nodeRunningState = BTRunningState.End; };
    }
    public void SetState(EnemyState state)
    {
        if(_state != EnemyState.Die)
            _state = state;
    }
    
    protected virtual SelectorBtNode CreateBT()
    {
        return new SelectorBtNode(new List<BTNode>()
        {
            CreateDieNode(),
            CreateStunNode(),
            CreateHitNode(),
            CreateAttackChaseNode(),
        });
    }
    
    protected virtual SequenceBtNode CreateAttackChaseNode()
    {
        
        InverterDecorator actionWaitNode = new InverterDecorator(new ActionBtNode(NodeRunningWait));
        
        SuccessDecorator waitNode = new SuccessDecorator (new SequenceBtNode(new List<BTNode>()
        {
            actionWaitNode, // 애니메이션이 실행중이면 대기, 끝나면 다음으로, 애니메이션이 실행되지 않고있으면 올라가기
            new ActionBtNode(() => CheckState(EnemyState.Attack)), // 애니메이션이 끝났는데 액션상태면
            new ActionBtNode(() => StopAnimation(_animationController.StopAttack))  // 애니메이션 멈추기
        }));
        SequenceBtNode actionNode = new SequenceBtNode(new List<BTNode>()
        {
            waitNode,   // 애니메이션 대기
            new ConditionalDecorator(IsTargetInAttackRange, new ActionBtNode(AttackAction), new ActionBtNode(Chase)),
        });
        return actionNode;
    }

    protected virtual SequenceBtNode CreateHitNode()
    {
        SequenceBtNode actionNode = new SequenceBtNode(new List<BTNode>()
        {
            new ActionBtNode(()=>CheckState(EnemyState.Hit)),
            new ActionBtNode(HitAction),
        });
        return actionNode;
    }
    
    protected virtual SelectorBtNode CreateDieNode()
    {

        SequenceBtNode deadNode = new SequenceBtNode(new List<BTNode>()
        {
            new ActionBtNode(() => CheckState(EnemyState.Dead)),
            new ActionBtNode(NodeRunningWait),
            new ActionBtNode(DeadAction)
        });
        SequenceBtNode dieNode = new SequenceBtNode(new List<BTNode>()
        {
            new ActionBtNode(()=>CheckState(EnemyState.Die)),
            new ActionBtNode(DieAction),
        });
        SelectorBtNode actionNode = new SelectorBtNode(new List<BTNode>()
        {
            deadNode,
            dieNode,
        });
        return actionNode;
    }
    protected virtual SequenceBtNode CreateStunNode()
    {
        
        SequenceBtNode actionNode = new SequenceBtNode(new List<BTNode>()
        {
            new ActionBtNode(()=>CheckState(EnemyState.Stun)),
            new ActionBtNode(StunAction),
        });
        return actionNode;
    }
    
    protected bool IsTargetInAttackRange()
    {
        float distanceSquared = (transform.position - _target.position).sqrMagnitude;
        return distanceSquared < _attackRange * _attackRange;
    }
    
    protected NodeState Chase()
    {
        _controller.MoveTowardsTarget(_target,1f);
        return NodeState.Success;
    }
    
    protected NodeState NodeRunningWait()
    {
        switch (_nodeRunningState)
        {
            case BTRunningState.Wait:
                return NodeState.Failure;
            case BTRunningState.InPlay:
                return NodeState.Running;
            case BTRunningState.End:
                return NodeState.Success;
        }

        return NodeState.Failure;
    }
    
    protected NodeState StopAnimation(Action action)
    {
        action();
        return NodeState.Success;
    }
    
    
    protected NodeState AttackAction()
    {
        _animationController.Attack(0);
        _nodeRunningState = BTRunningState.InPlay;
        return NodeState.Success;
    }

    protected NodeState StunAction()
    {
        _animationController.Stun();
        _nodeRunningState = BTRunningState.InPlay;
        return NodeState.Success;
    }

    protected NodeState HitAction()
    {
        _animationController.Hit();
        _state = EnemyState.Idle;
        
        _nodeRunningState = BTRunningState.InPlay;
        return NodeState.Success;
    }
    
    protected NodeState DieAction()
    {
        _animationController.Die();
        _state = EnemyState.Dead;
        _nodeRunningState = BTRunningState.InPlay;
        return NodeState.Success;
    }

    protected NodeState DeadAction()
    {
        this.gameObject.SetActive(false);
        return NodeState.Success;
    }

    protected NodeState CheckState(EnemyState state)
    {
        if(_state == state)
            return NodeState.Success;
        return NodeState.Failure;
    }
    
}
