﻿using System;
using GameDevProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Animation;

namespace GameDevProject.Collectibles
{
    public class Tea : IPowerUp
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Vector2 position;

        public Tea(Texture2D texture, Rectangle sourceRectangle)
        {
            this.texture = texture;
            this.sourceRectangle = sourceRectangle;
        }

        public void Collect(Alice alice)
        {
            ApplyEffect(alice);
        }

        public void ApplyEffect(Alice alice)
        {
            // Increase attack speed
            alice.attackSpeed += 50f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White);
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
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
