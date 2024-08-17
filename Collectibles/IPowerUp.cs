using System;
using GameDevProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Collectibles
{
    public interface IPowerUp : ICollectible
    {
        //power ups apply an effect or make player stronger
        void ApplyEffect(Alice alice);
        void SetPosition(Vector2 position);
    }
}
