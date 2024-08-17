using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject;

public class Enemy
{
    public Vector2 Position { get; set; }
    public float Speed { get; set; }
    private IMovementStrategy movementStrategy;

    private Texture2D texture;

    public Enemy(Texture2D texture, IMovementStrategy strategy)
    {
        this.texture = texture;
        this.movementStrategy = strategy;
    }

    public void Update(GameTime gameTime, Alice alice)
    {
        movementStrategy.Move(this, alice, gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, Position, Color.White);
    }

    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        this.movementStrategy = strategy;
    }
}
