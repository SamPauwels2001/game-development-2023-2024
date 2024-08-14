using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Input;

class KeyboardReader : IInputReader
{
    public bool IsDestinationInput => false;

    public Vector2 ReadInput()
    {
        KeyboardState state = Keyboard.GetState();
        Vector2 direction = Vector2.Zero;        

        // Horizontal movement
        if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Q))
        {
            direction.X -= 1;
        }
        else if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
        {
            direction.X += 1;
        }

        // Vertical movement
        if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W) || state.IsKeyDown(Keys.Z))
        {
            direction.Y -= 1;
        }
        else if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
        {
            direction.Y += 1;
        }

        return direction;
    }
}
