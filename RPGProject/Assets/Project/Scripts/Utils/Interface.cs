public interface IDamageable
{
    public void TakeDamage(AttackHandler attackHandler);
}

public interface IHealable
{
    public void ReceiveHealing();
}
