using System;
using GameDevProject;

public class Watch : IPowerUp
{
    public void Collect(Alice alice)
    {
        ApplyEffect(alice);
    }

    public void ApplyEffect(Alice alice)
    {
        //Decrease attack cooldown
    }
}
