using System;

public interface IDamageable
{
    public event Action OnDie;
    public void TakeDamage(AttackHandler attackHandler);
}

public interface IHealable
{
    public void ReceiveHealing();
}

public interface ICommand
{
    public void Execute();
}
public interface ICommandUndo : ICommand
{
    public void Undo();
}