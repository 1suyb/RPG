public class CharacterEquipChangeState : CharacterGroundState
{
    private string _equipChangeTag;
    private float _prevSpeedModifier;
    public CharacterEquipChangeState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        _equipChangeTag = _animationController.EquipChangeTag;
    }

    public override void Enter()
    {
        base.Enter();
        _animationController.Equip(IsEquipped);
        _prevSpeedModifier = SpeedModifier;
        SpeedModifier = 0;
    }

    public override void Exit()
    {
        base.Exit();
        SpeedModifier = _prevSpeedModifier;
    }

    public override void Update()
    {
        base.Update();
        if (_stateMachine.AnimationController.IsPlayAnimation(_equipChangeTag) >= 1f ||
            _stateMachine.AnimationController.IsPlayAnimation(_equipChangeTag) <= -1f)
        {
            IsEquipped = !IsEquipped;
            IsEquipChange = false;
        }
    }
}