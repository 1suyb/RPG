public class CharacterGroundState : CharacterBaseState
{
    protected bool IsDodge
    {
        get => StateMachine.IsDodge;
        set => StateMachine.IsDodge = value;
    }
    public CharacterGroundState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (!IsGrounded)
        {
            // Air 상태로 전이
        }
        if (IsDodge)
        {
            if((CharacterBaseState)StateMachine.CurrentState!=StateMachine.Dodge)
                StateMachine.ChangeState(StateMachine.Dodge);
        }
        else if(IsMove)
        {
            // Walk 상태로 전이
            if((CharacterBaseState)StateMachine.CurrentState!=StateMachine.Move)
                StateMachine.ChangeState(StateMachine.Move);
        }
        else
        {
            // Idle 상태로 전이
            if((CharacterBaseState)StateMachine.CurrentState!=StateMachine.Idle)
                StateMachine.ChangeState(StateMachine.Idle);
        }
    }

    protected override void SubscribeEvents()
    {
        base.SubscribeEvents();
        StateMachine.InputEventListener.OnDodgeInputDown += Dodge;

    }

    protected override void DeSubscribeEvents()
    {
        base.DeSubscribeEvents();
        StateMachine.InputEventListener.OnDodgeInputDown -= Dodge;
    }

    protected void Dodge()
    {
        IsDodge = true;
    }
}