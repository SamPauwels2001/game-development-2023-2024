using System;

public interface IItem : ICollectible
{
    //items add points to the score
    int Points { get; }
}
