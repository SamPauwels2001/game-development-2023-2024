using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Interfaces;

public abstract class Block : IGameObject
{
    public Rectangle BoundingBox { get; set; }
    public bool Passable { get; set; }
    public Texture2D Texture { get; set; }
    public Rectangle SourceRectangle { get; set; }

    public Block(int x, int y, int width, int height, Texture2D texture, Rectangle sourceRectangle, bool passable = true)
    {
        BoundingBox = new Rectangle(x, y, width, height);
        Passable = passable;
        this.Texture = texture;
        SourceRectangle = sourceRectangle;
    }

    public abstract void Update(GameTime gameTime);

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, BoundingBox, SourceRectangle, Color.White);
    }

    public bool CheckCollision(Rectangle aliceBoundingBox)
    {
        if (!Passable && BoundingBox.Intersects(aliceBoundingBox))
        {
            // Collision detected
            return true;
        }
        return false;
    }
}

