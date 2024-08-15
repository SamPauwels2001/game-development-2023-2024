using System;
using GameDevProject;

public class Tea : IPowerUp
{
    public void Collect(Alice alice)
    {
        ApplyEffect(alice);
    }

    public void ApplyEffect(Alice alice)
    {
        // Increase attack speed
        alice.attackSpeed += 50f;
    }
}
