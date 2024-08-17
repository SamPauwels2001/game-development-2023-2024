using System;
using GameDevProject;

namespace GameDevProject.Collectibles
{
    public interface IItem : ICollectible
    {
        //items add points to the score
        int Points { get; }
    }
}
