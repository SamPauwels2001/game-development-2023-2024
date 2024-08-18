using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class FenceBlock : Block
{
    public FenceBlock(int x, int y, int width, int height, Texture2D fenceTexture)
        : base(x, y, width, height, fenceTexture, false)
    {

    }

    public override void Update(GameTime gameTime)
    {
        
    }
}
