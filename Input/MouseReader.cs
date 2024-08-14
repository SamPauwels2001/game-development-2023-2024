using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Input;

class MouseReader : IInputReader
{
    public bool IsDestinationInput => true;

    public Vector2 ReadInput()
    {
        MouseState state = Mouse.GetState();
        Vector2 directionMouse = new Vector2(state.X, state.Y);
        return directionMouse;
    }

    public bool IsLeftMouseClick()
    {
        MouseState state = Mouse.GetState();
        return state.LeftButton == ButtonState.Pressed;
    }

}
