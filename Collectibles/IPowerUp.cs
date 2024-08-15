using System;
using GameDevProject;

public interface IPowerUp : ICollectible
{
    //power ups apply an effect or make player stronger
    void ApplyEffect(Alice alice);
}
