using System;

public class Cake : IItem
{
    public int Points { get; } = 100;

    public void Collect(Player player)
    {
        //AddPoints(Points);        
    }
}

