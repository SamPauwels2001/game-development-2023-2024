using GameDevProject.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDevProject.Interfaces;

namespace GameDevProject
{
    internal class Alice:IGameObject
    {
        Texture2D aliceTexture;
        Animation.Animation aliceAnimation;
        private Vector2 position;
        private Vector2 speed;
        private Vector2 acceleration;


        public Alice(Texture2D texture)
        {
            aliceTexture = texture;
            aliceAnimation = new Animation.Animation();
            //aliceAnimation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 76, 134)));
            aliceAnimation.AddFrame(new AnimationFrame(new Rectangle(76, 0, 76, 134)));
            aliceAnimation.AddFrame(new AnimationFrame(new Rectangle(152, 0, 76, 134)));
            position = new Vector2(0, 0);
            speed = new Vector2(1, 1);
            acceleration = new Vector2(0.1f, 0.1f);
        }

        public void Update(GameTime gameTime)
        {
            aliceAnimation.Update(gameTime);
            Move();
        }

        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }


        private void Move()
        {
            position += speed;
            speed += acceleration;
            float maxSpeed = 6;
            speed = Limit(speed, maxSpeed);
            if (position.X + speed.X > 800 - 70 || position.X + speed.X < 0)
            {
                speed = new Vector2
                (speed.X < 0 ? 1 : -1, speed.Y);
                acceleration.X *= -1;
            }
            if (position.Y + speed.Y > 480 -125 || position.Y + speed.Y < 0)
            {
                speed = new Vector2
                (speed.X, speed.Y < 0 ? 1 : -1);
                acceleration.Y *= -1;

            }

        }


        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(aliceTexture, new Vector(0, 0), aliceAnimation.CurrentFrame.SourceRectangle, Color.White);
            spriteBatch.Draw(aliceTexture, position, aliceAnimation.CurrentFrame.SourceRectangle, Color.White);
        }

    }
}
