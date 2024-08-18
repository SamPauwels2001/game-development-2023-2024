﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject;
using Microsoft.Xna.Framework.Content;

public class Level2 : Level
{
    private Block[,] gameBoard;

    public Level2(Game1 game, SpriteBatch spriteBatch, ContentManager content)
        : base(game, spriteBatch, content) { }

    public override void LoadContent()
    {
        base.LoadContent();

        int tileWidth = 48;
        int tileHeight = 48;
        int numTilesX = (int)Math.Ceiling((double)Game1.ScreenWidth / tileWidth);
        int numTilesY = (int)Math.Ceiling((double)Game1.ScreenHeight / tileHeight);

        gameBoard = new Block[numTilesX, numTilesY];

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
                    tileSet, sandSourceRectangle
                );
            }
        }
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        // Update level
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

        spriteBatch.End();

        base.Draw(gameTime);

    }

    public override void UnloadContent()
    {
        base.UnloadContent();
        // Unload level-specific content
    }
}