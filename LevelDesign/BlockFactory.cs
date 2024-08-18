using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BlockFactory
{
public static Block CreateBlock(string type, int x, int y, int width, int height, Texture2D tileSetTexture, Rectangle sourceRectangle)
    {
        switch (type.ToUpper())
        {
            case "GRASS":
                return new GrassBlock(x, y, width, height, tileSetTexture, sourceRectangle);
            case "BUSH":
                return new BushBlock(x, y, width, height, tileSetTexture, sourceRectangle);
            case "FLOWER":
                return new FlowerBlock(x, y, width, height, tileSetTexture, sourceRectangle);
            case "ROCK":
                return new RockBlock(x, y, width, height, tileSetTexture, sourceRectangle);
            case "FENCE":
                return new FenceBlock(x, y, width, height, tileSetTexture, sourceRectangle);
            case "BARREL":
                return new BarrelBlock(x, y, width, height, tileSetTexture, sourceRectangle);
            default:
                throw new ArgumentException("Invalid block type");
        }
    }
}
