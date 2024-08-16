using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class GrassBlock : Block
{
    public GrassBlock(int x, int y, GraphicsDevice graphics) : base(x, y, graphics)
    {
        BoundingBox = new Rectangle(x, y, 10, 10);
        Passable = true;
        Texture = new Texture2D(graphics, 1, 1);
        CollideWithEvent = new NoEvent();
    }

}
