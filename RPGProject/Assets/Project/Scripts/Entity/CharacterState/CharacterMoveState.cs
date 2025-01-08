using UnityEngine;

public class CharacterMoveState : CharacterGroundState
{
    public CharacterMoveState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
}

public class CharacterIdleState : CharacterGroundState
{
    public CharacterIdleState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
}
public class CharacterDodgeState : CharacterGroundState
{
    private int _animHash;
    private string _animTag;
    private Vector3 _moveDir;
    
    public CharacterDodgeState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        _animHash = StateMachine.AnimData.IsDodge.Hash;
        _animTag = StateMachine.AnimData.IsDodge.Tag;
    }

    public override void Enter()
    {
        base.Enter();
        _moveDir = MoveDir == Vector3.zero ? Vector3.forward: MoveDir;
        SpeedModifier = 2;
        StartAnimation(_animHash);
        
    }

    public override void Update()
    {
        if (StateMachine.AnimationController.IsPlayAnimation(_animTag) >= 1f ||
            StateMachine.AnimationController.IsPlayAnimation(_animTag) <= -1f)
        {
            IsDodge = false;
        }
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_animHash);
        SpeedModifier = 1;
    }

    protected override void Move()
    {
        StateMachine.AnimationController.SetFloat(MoveZAnimHash, _moveDir.z);
        StateMachine.AnimationController.SetFloat(MoveXAnimHash, _moveDir.x);
        StateMachine.Controller.Move(_moveDir,SpeedModifier);
    }
}