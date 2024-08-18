using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class GrassBlock : Block
{

    public GrassBlock(int x, int y, int width, int height, Texture2D tileSetTexture, Rectangle sourceRectangle)
        : base(x, y, width, height, tileSetTexture, sourceRectangle, true)
    {

    }

    public override void Update(GameTime gameTime)
    {
        // update
    }

}
