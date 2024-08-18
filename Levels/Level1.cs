using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject;
using Microsoft.Xna.Framework.Content;

public class Level1 : Level
{
    private Block[,] gameBoard;
    private Block[,] detailBoard;

    public Level1(Game1 game, SpriteBatch spriteBatch, ContentManager content) 
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

    private void PlaceDetailBlocks()
    {
        AddDetailBlock("FLOWER", 2, 3, 26, 26);
        AddDetailBlock("FLOWER", 3, 3, 26, 26);
        AddDetailBlock("FLOWER", 2, 4, 26, 26);
        AddDetailBlock("FLOWER", 5, 5, 26, 26);

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
        spriteBatch.Begin();

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


        spriteBatch.End();

        base.Draw(gameTime);

    }

    public override void UnloadContent()
    {
        base.UnloadContent();
        // Unload level-specific content
    }

    private void AddDetailBlock(string type, int x, int y, int tileWidth, int tileHeight)
    {
        if (x >= 0 && x < gameBoard.GetLength(0) && y >= 0 && y < gameBoard.GetLength(1))
        {
            detailBoard[x, y] = BlockFactory.CreateBlock(
                type, x * tileWidth, y * tileHeight, tileWidth, tileHeight,
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
