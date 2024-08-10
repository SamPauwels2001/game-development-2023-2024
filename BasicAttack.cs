using System;

public class BasicAttack : IAttack
{
    private int damage;

    public BasicAttack(int damage)
    {
        this.damage = damage;
    }

    public void Execute(IAttackable target)
    {
        target.TakeDamage(damage);
    }
}
