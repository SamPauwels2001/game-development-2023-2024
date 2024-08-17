using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Interfaces;
using GameDevProject;

public class ProjectileAttack : IAttack
{
    private Vector2 _position;
    private Vector2 _direction;
    private float _speed;
    private Texture2D _texture;
    private bool _isActive;

    public bool IsActive => _isActive;

    public Vector2 Position => _position;

    public int Width => _texture.Width;
    public int Height => _texture.Height;

    public ProjectileAttack(Texture2D texture, Vector2 position, Vector2 direction, float speed)
    {
        _texture = texture;
        _position = position;
        _direction = direction;
        _speed = speed;
        _isActive = true;
    }

    public void ExecuteAttack(Vector2 position, Vector2 direction)
    {
        _position = position;
        _direction = direction;
    }

    public void Update(GameTime gameTime)
    {
        _position += _direction * _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        // Check if the projectile is out of bounds or hits something
        if (_position.X < 0 || _position.X > Game1.ScreenWidth || _position.Y < 0 || _position.Y > Game1.ScreenHeight)
        {
            _isActive = false;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, Color.White);
    }

    public void Deactivate()
    {
        _isActive = false;
    }
}
