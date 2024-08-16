using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block : IGameObject
{
    public Rectangle BoundingBox { get; set; }
    public bool Passable { get; set; }
    public Texture2D Texture { get; set; }
    public CollideWithEvent CollideWithEvent { get; set; }

    public Block(int x, int y, GraphicsDevice graphics)
    {
        BoundingBox = new Rectangle(x, y, 10, 10);
        Passable = false;
        Texture = new Texture2D(graphics, 1, 1);
        CollideWithEvent = new NoEvent();
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, BoundingBox);
    }
    public virtual void IsCollidedWithEvent
    (Character collider)
    {
        CollideWithEvent.Execute();
    }
}

