using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class RockBlock : Block
{
    public RockBlock(int x, int y, int width, int height, Texture2D rockTexture)
        : base(x, y, width, height, rockTexture, false)
    {

    }

    public override void Update(GameTime gameTime)
    {
        
    }
}
