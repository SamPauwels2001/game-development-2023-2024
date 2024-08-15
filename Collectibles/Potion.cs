using System;
using GameDevProject;

public class Potion : IItem
{
    public int Points { get; } = 50;

    public void Collect(Alice alice)
    {
        alice.PlayerScore.AddPoints(Points);        
    }
}
