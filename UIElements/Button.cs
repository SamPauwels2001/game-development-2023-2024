using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameDevProject.Input;

public class Button
{
    private Texture2D _texture;
    private Rectangle _bounds;
    private Action _onClick;

    public Button(Texture2D texture, Rectangle bounds, Action onClick)
    {
        _texture = texture;
        _bounds = bounds;
        _onClick = onClick;
    }

    public void Update(MouseState mouseState)
    {
        if (_bounds.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
        {
            _onClick?.Invoke();
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _bounds, Color.White);
    }
}
