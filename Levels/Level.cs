using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameDevProject.Input;
using System.Collections.Generic;
using GameDevProject.Interfaces;
using GameDevProject;
using GameDevProject.Collectibles;
using Microsoft.Xna.Framework.Content;

public abstract class Level
{
    protected Game1 game;
    protected SpriteBatch spriteBatch;
    protected ContentManager content;
    protected Alice alice;
    protected List<IPowerUp> powerUps;
    protected PowerUpSpawner powerUpSpawner;

    public Level(Game1 game, SpriteBatch spriteBatch, ContentManager content)
    {
        this.game = game;
        this.spriteBatch = spriteBatch;
        this.content = content;
        powerUps = new List<IPowerUp>();
    }

    public virtual void LoadContent() 
    {
        var aliceTexture = content.Load<Texture2D>("AliceSprite");
        var attackBubbleTexture = content.Load<Texture2D>("AttackBubble");
        var itemTexture = content.Load<Texture2D>("ItemsSprite");

        alice = new Alice(aliceTexture, attackBubbleTexture, new KeyboardReader(), new MouseReader());

        var itemFactory = new ItemFactory(itemTexture);
        var powerUpFactory = new PowerUpFactory(itemTexture);

        powerUpSpawner = new PowerUpSpawner(powerUpFactory, Game1.ScreenWidth, Game1.ScreenHeight);
    }

    public virtual void Update(GameTime gameTime) 
    {
        alice.Update(gameTime);

        var powerUp = powerUpSpawner.TrySpawnPowerUp();
        if (powerUp != null)
        {
            powerUps.Add(powerUp);
            //Console.WriteLine($"Power-up spawned at: {powerUp.Position}");
        }

        foreach (var spawnedPowerUp in powerUps)
        {
            // update existing powerups or something idk
        }
    }

    public virtual void Draw(GameTime gameTime) 
    {
        spriteBatch.Begin();

        alice.Draw(spriteBatch);

        foreach (var powerUp in powerUps)
        {
            powerUp.Draw(spriteBatch);
        }

        spriteBatch.End();
    }

    public virtual void UnloadContent() 
    { 
        //unload level specific content
    }
}
