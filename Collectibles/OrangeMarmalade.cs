using System;

public class OrangeMarmalade : IPowerUp
{
    public void Collect(Player player)
    {
        ApplyEffect(player);
    }

    public void ApplyEffect(Player player)
    {
        // make player temporarily invincible
    }
}