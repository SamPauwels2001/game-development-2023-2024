using System;
using GameDevProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Animation;

namespace GameDevProject.Collectibles
{
    public class Potion : IItem
    {
        public int Points { get; } = 50;
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Vector2 position;

        public Potion(Texture2D texture, Rectangle sourceRectangle)
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
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White);
        }

        public int Width => sourceRectangle.Width;
        public int Height => sourceRectangle.Height;

        public Vector2 Position
        {
            get => position;
            set => position = value;
        }
    }
}
