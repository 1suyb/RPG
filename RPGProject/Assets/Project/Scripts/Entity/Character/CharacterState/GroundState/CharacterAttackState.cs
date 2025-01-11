public class CharacterAttackState : CharacterGroundState
{
    private string _attackTag;
    public CharacterAttackState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        _attackTag = _animationController.AttackTag;
    }
    public override void Enter()
    {
        base.Enter();
        _animationController.StartAttack(AttackNumber);
    }

    public override void Exit()
    {
        base.Exit();
        _animationController.StopAttack();
    }

    public override void Update()
    {
        base.Update();
    }
    
}