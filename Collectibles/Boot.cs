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
        //Increase movement speed
    }
}
