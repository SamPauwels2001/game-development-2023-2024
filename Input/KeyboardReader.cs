using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Input;

class KeyboardReader : IInputReader
{
    public Vector2 ReadInput()
    {
        KeyboardState state = Keyboard.GetState();
        Vector2 direction = Vector2.Zero;

        if (state.IsKeyDown(Keys.A))
        {
            direction.X -= 1;
        }
        if (state.IsKeyDown(Keys.D))
        {
            direction.X += 1;
        }
        if (state.IsKeyDown(Keys.W))
        {
            direction.Y -= 1;
        }
        if (state.IsKeyDown(Keys.S))
        {
            direction.Y += 1;
        }

        return direction;
    }
}
