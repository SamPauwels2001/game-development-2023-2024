using GameDevProject.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    internal class Alice
    {
        Texture2D aliceTexture;
        Animation.Animation aliceAnimation;
        public Alice(Texture2D texture)
        {
            aliceTexture = texture;
            aliceAnimation = new Animation.Animation();
            aliceAnimation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 76, 134)));
            aliceAnimation.AddFrame(new AnimationFrame(new Rectangle(76, 0, 76, 134)));
            aliceAnimation.AddFrame(new AnimationFrame(new Rectangle(152, 0, 76, 134)));

        }

        public void Update(GameTime gameTime)
        {
            aliceAnimation.Update(gameTime);
        }
        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(aliceTexture, new Vector2(0, 0), aliceAnimation.CurrentFrame.SourceRectangle, Color.White);
        }

    }
}
