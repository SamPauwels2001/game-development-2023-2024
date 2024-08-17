using System;
using GameDevProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Collectibles
{
    public interface ICollectible
    {
        void Collect(Alice alice);
        void Draw(SpriteBatch spriteBatch);
        int Width { get; }
        int Height { get; }
        Vector2 Position { get; set; }
    }

}
