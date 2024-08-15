using System;

public class Watch : IPowerUp
{
    public void Collect(Player player)
    {
        ApplyEffect(player);
    }

    public void ApplyEffect(Player player)
    {
        //Decrease attack cooldown
    }
}
