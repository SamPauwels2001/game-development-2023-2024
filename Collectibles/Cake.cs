using System;
using GameDevProject;

public class Cake : IItem
{
    public int Points { get; } = 100;

    public void Collect(Alice alice)
    {
        alice.PlayerScore.AddPoints(Points);
    }
}

