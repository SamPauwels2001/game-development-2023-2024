using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject;
using Microsoft.Xna.Framework.Content;

public class Level3 : Level
{
    private new Block[,] gameBoard;
    private Block[,] detailBoard;

    public Level3(Game1 game, SpriteBatch spriteBatch, ContentManager content)
        : base(game, spriteBatch, content) { }

    public override void LoadContent()
    {
        base.LoadContent();

        int tileWidth = 64;
        int tileHeight = 64;
        int numTilesX = (int)Math.Ceiling((double)Game1.ScreenWidth / tileWidth);
        int numTilesY = (int)Math.Ceiling((double)Game1.ScreenHeight / tileHeight);

        gameBoard = new Block[numTilesX, numTilesY];
        detailBoard = new Block[numTilesX, numTilesY];

        for (int x = 0; x < numTilesX; x++)
        {
            for (int y = 0; y < numTilesY; y++)
            {
                int posX = x * tileWidth;
                int posY = y * tileHeight;

                if (posX >= Game1.ScreenWidth || posY >= Game1.ScreenHeight)
                    continue;

                gameBoard[x, y] = BlockFactory.CreateBlock(
                    "GRASS", posX, posY, tileWidth, tileHeight,
                    tileSet, grassSourceRectangle
                );
            }
        }

        PlaceDetailBlocks();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        // Update level 1
    }

    public override void Draw(GameTime gameTime)
    {

        for (int x = 0; x < gameBoard.GetLength(0); x++)
        {
            for (int y = 0; y < gameBoard.GetLength(1); y++)
            {
                gameBoard[x, y].Draw(spriteBatch);
            }
        }

        for (int x = 0; x < detailBoard.GetLength(0); x++)
        {
            for (int y = 0; y < detailBoard.GetLength(1); y++)
            {
                if (detailBoard[x, y] != null)
                {
                    detailBoard[x, y].Draw(spriteBatch);
                }
            }
        }

        base.Draw(gameTime);

    }

    private void PlaceDetailBlocks()
    {
        AddDetailBlock("BUSH", 1, 1, 44, 34);
        AddDetailBlock("BUSH", 15, 15, 44, 34);
        AddDetailBlock("BUSH", 16, 11, 44, 34);
        AddDetailBlock("BUSH", 26, 1, 44, 34);
        AddDetailBlock("BUSH", 12, 15, 44, 34);
        AddDetailBlock("BUSH", 16, 5, 44, 34);

        AddDetailBlock("BARREL", 0, 0, 40, 44);
        AddDetailBlock("BARREL", 0, 6, 40, 44);

        AddDetailBlock("FLOWER", 1, 6, 26, 26);
        AddDetailBlock("FLOWER", 17, 12, 26, 26);
        AddDetailBlock("FLOWER", 2, 8, 26, 26);

        AddDetailBlock("ROCK", 1, 2, 44, 34);
        AddDetailBlock("ROCK", 14, 16, 44, 34);
        AddDetailBlock("ROCK", 0, 10, 44, 34);
        AddDetailBlock("ROCK", 23, 4, 44, 34);
        AddDetailBlock("ROCK", 27, 15, 44, 34);
    }

    public override void UnloadContent()
    {
        base.UnloadContent();
        // Unload level-specific content
    }

    private void AddDetailBlock(string type, int x, int y, int blockWidth, int blockHeight)
    {
        if (x >= 0 && x < gameBoard.GetLength(0) && y >= 0 && y < gameBoard.GetLength(1))
        {
            int posX = x * 64 + (64 - blockWidth) / 2;
            int posY = y * 64 + (64 - blockHeight) / 2;

            detailBoard[x, y] = BlockFactory.CreateBlock(
                type, posX, posY, blockWidth, blockHeight,
                tileSet, GetSourceRectangleForType(type)
            );
        }
    }

    private Rectangle GetSourceRectangleForType(string type)
    {
        switch (type.ToUpper())
        {
            case "FLOWER": return flowerSourceRectangle;
            case "BARREL": return barrelSourceRectangle;
            case "ROCK": return rockSourceRectangle;
            case "BUSH": return bushSourceRectangle;

            default: return grassSourceRectangle; // Default grass
        }
    }
}
