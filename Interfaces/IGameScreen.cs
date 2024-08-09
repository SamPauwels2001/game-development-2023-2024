using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameDevProject.Input;

namespace GameDevProject.Interfaces
{
    public interface IGameScreen
    {
        void Update(GameTime gameTime, MouseState mouseState);
        void Draw(SpriteBatch spriteBatch);
    }
}

