using System;
using GameDevProject;

public class OrangeMarmalade : IPowerUp
{
    public void Collect(Alice alice)
    {
        ApplyEffect(alice);
    }

    public void ApplyEffect(Alice alice)
    {
        // make player temporarily invincible
    }
}