using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject;


public class Enemy
{
    public Vector2 Position { get; set; }
    public float Speed { get; set; }

    private Texture2D texture;

    public Enemy(Texture2D texture)
    {
        this.texture = texture;
    }

    public void Update(GameTime gameTime)
    {
        //update enemy
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, Position, Color.White);
    }
}
