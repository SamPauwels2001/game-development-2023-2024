using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BushBlock : Block
{
    public BushBlock(int x, int y, int width, int height, Texture2D tileSetTexture, Rectangle sourceRectangle)
        : base(x, y, width, height, tileSetTexture, sourceRectangle, false)
    {

    }

    public override void Update(GameTime gameTime)
    {

    }
}
