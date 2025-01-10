using UnityEngine;

public class CharacterDodgeState : CharacterGroundState
{
    private string _dodgeTag;
    private Vector3 _moveDir;
    
    public CharacterDodgeState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        _dodgeTag = stateMachine.AnimationController.DodgeTag;
    }

    public override void Enter()
    {
        base.Enter();
        _moveDir = MoveDir == Vector3.zero ? Vector3.forward: MoveDir;
        SpeedModifier = 2;
        _animationController.Dodge();
        
    }

    public override void Update()
    {
        if (_stateMachine.AnimationController.IsPlayAnimation(_dodgeTag) >= 1f ||
            _stateMachine.AnimationController.IsPlayAnimation(_dodgeTag) <= -1f)
        {
            IsDodge = false;
        }
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
        SpeedModifier = 1;
    }

    protected override void Move()
    {
        Quaternion rotateVec = EntityController.RotateVector(LookDir);
        Vector3 animDir = rotateVec * MoveDir;
        _animationController.SetMoveDir(animDir.z, animDir.x);
        _stateMachine.Controller.Move(_moveDir,SpeedModifier);
    }
}