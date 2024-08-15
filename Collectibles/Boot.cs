using System;

public class Boot : IPowerUp
{
    public void Collect(Player player)
    {
        ApplyEffect(player);        
    }

    public void ApplyEffect(Player player)
    {
        //Increase movement speed
    }
}
