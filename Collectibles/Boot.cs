using System;
using GameDevProject;

public class Boot : IPowerUp
{
    public void Collect(Alice alice)
    {
        ApplyEffect(alice);        
    }

    public void ApplyEffect(Alice alice)
    {
        //increase movement speed by increasing MaxSpeed
        alice.MaxSpeed += 2;
    }
}
