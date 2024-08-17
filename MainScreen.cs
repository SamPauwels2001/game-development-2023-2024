using System;
using Microsoft.Xna.Framework;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using GameDevProject.Input;

public class MainScreen : IGameScreen
{
    private Background _background;
    private List<Button> _buttons;

    public MainScreen(Background background, List<Button> buttons)
    {
        _background = background;
        _buttons = buttons;
    }

    public void Update(GameTime gameTime, MouseState mouseState)
    {
        foreach (var button in _buttons)
        {
            button.Update(mouseState);
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();

        _background.Draw(spriteBatch);
        foreach (var button in _buttons)
        {
            button.Draw(spriteBatch);
        }

        spriteBatch.End();
    }
}
