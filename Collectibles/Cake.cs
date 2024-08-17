using System;
using GameDevProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Animation;

namespace GameDevProject.Collectibles
{
    public class Cake : IItem
    {
        public int Points { get; } = 100;
        private Texture2D texture;
        private Rectangle sourceRectangle;

        public Cake(Texture2D texture, Rectangle sourceRectangle)
        {
            this.texture = texture;
            this.sourceRectangle = sourceRectangle;
        }

        public void Collect(Alice alice)
        {
            alice.PlayerScore.AddPoints(Points);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, sourceRectangle, Color.White);
        }
        //, Vector2 position
    }
}

