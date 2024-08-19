using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

public class Level1 : Level
{
    private new Block[,] gameBoard;
    private new Block[,] detailBoard;

    public Level1(Game1 game, SpriteBatch spriteBatch, ContentManager content) 
        : base(game, spriteBatch, content) 
    {

    }

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

    private void PlaceDetailBlocks()
    {
        AddDetailBlock("FLOWER", 2, 3, 26, 26);
        AddDetailBlock("FLOWER", 3, 3, 26, 26);
        AddDetailBlock("FLOWER", 2, 4, 26, 26);
        AddDetailBlock("FLOWER", 5, 5, 26, 26);
        AddDetailBlock("FLOWER", 1, 1, 26, 26);
        AddDetailBlock("FLOWER", 12, 15, 26, 26);
        AddDetailBlock("FLOWER", 20, 15, 26, 26);
        AddDetailBlock("FLOWER", 28, 1, 26, 26);
        AddDetailBlock("FLOWER", 12, 5, 26, 26);
        AddDetailBlock("FLOWER", 8, 14, 26, 26);
        AddDetailBlock("FLOWER", 3, 12, 26, 26);
        AddDetailBlock("FLOWER", 15, 7, 26, 26);
        AddDetailBlock("FLOWER", 20, 2, 26, 26);
        AddDetailBlock("FLOWER", 18, 11, 26, 26);
        AddDetailBlock("FLOWER", 7, 9, 26, 26);
        AddDetailBlock("FLOWER", 25, 3, 26, 26);
        AddDetailBlock("FLOWER", 29, 16, 26, 26);
        AddDetailBlock("FLOWER", 21, 13, 26, 26);
        AddDetailBlock("FLOWER", 6, 1, 26, 26);
        AddDetailBlock("FLOWER", 10, 4, 26, 26);
        AddDetailBlock("FLOWER", 22, 6, 26, 26);
        AddDetailBlock("FLOWER", 27, 15, 26, 26);
        AddDetailBlock("FLOWER", 30, 1, 26, 26);
        AddDetailBlock("FLOWER", 13, 8, 26, 26);
        AddDetailBlock("FLOWER", 2, 1, 26, 26);
        AddDetailBlock("FLOWER", 19, 14, 26, 26);
        AddDetailBlock("FLOWER", 5, 10, 26, 26);
        AddDetailBlock("FLOWER", 16, 3, 26, 26);
        AddDetailBlock("FLOWER", 24, 9, 26, 26);
        AddDetailBlock("FLOWER", 9, 2, 26, 26);
        AddDetailBlock("FLOWER", 26, 11, 26, 26);
        AddDetailBlock("FLOWER", 17, 12, 26, 26);
        AddDetailBlock("FLOWER", 1, 7, 26, 26);
        AddDetailBlock("FLOWER", 23, 8, 26, 26);
        AddDetailBlock("FLOWER", 14, 15, 26, 26);
        AddDetailBlock("FLOWER", 4, 6, 26, 26);
        AddDetailBlock("FLOWER", 1, 13, 26, 26);
        AddDetailBlock("FLOWER", 11, 16, 26, 26);

        AddDetailBlock("FENCE", 10, 15, 114, 40);
        AddDetailBlock("FENCE", 15, 10, 114, 40);
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
            case "FENCE": return fenceSourceRectangle;

            default: return grassSourceRectangle; // Default grass
        }
    }

}
