using System;

public class Potion : IItem
{
    public int Points { get; } = 50;

    public void Collect(Player player)
    {
        //AddPoints(Points);        
    }
}
