using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Input;

class MouseReader : IInputReader
{
    private ButtonState previousLeftButtonState;

    public MouseReader()
    {
        previousLeftButtonState = ButtonState.Released;
    }

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
        bool isSingleClick = previousLeftButtonState == ButtonState.Released &&
                             currentState.LeftButton == ButtonState.Pressed;
        previousLeftButtonState = currentState.LeftButton;
        return isSingleClick;
    }

}
