using System;

public interface IPowerUp : ICollectible
{
    //power ups apply an effect or make player stronger
    void ApplyEffect(Player player);
}
