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

    private List<Enemy> enemies;
    private EnemyFactory enemyFactory;

    public Level(Game1 game, SpriteBatch spriteBatch, ContentManager content)
    {
        this.game = game;
        this.spriteBatch = spriteBatch;
        this.content = content;
        powerUps = new List<IPowerUp>();

        enemies = new List<Enemy>();
        var enemyTexture = content.Load<Texture2D>("Card");
        enemyFactory = new EnemyFactory(enemyTexture);
    }

    public virtual void LoadContent() 
    {
        var aliceTexture = content.Load<Texture2D>("AliceSprite");
        var attackBubbleTexture = content.Load<Texture2D>("AttackBubble");
        var enemyProjectileTexture = content.Load<Texture2D>("EnemyProjectile");
        var heartTexture = content.Load<Texture2D>("Heart");
        var itemTexture = content.Load<Texture2D>("ItemsSprite");

        alice = new Alice(aliceTexture, attackBubbleTexture, new KeyboardReader(), new MouseReader());
        alice.HeartTexture = heartTexture;

        var itemFactory = new ItemFactory(itemTexture);
        var powerUpFactory = new PowerUpFactory(itemTexture);

        powerUpSpawner = new PowerUpSpawner(powerUpFactory, Game1.ScreenWidth, Game1.ScreenHeight);

        enemies.Add(enemyFactory.CreateStayAwayEnemy(new Vector2(100, 100), enemyProjectileTexture));
        enemies.Add(enemyFactory.CreateMoveCloserEnemy(new Vector2(200, 200), enemyProjectileTexture));
        enemies.Add(enemyFactory.CreateErraticEnemy(new Vector2(300, 300), enemyProjectileTexture));
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

        //powerups that have been collected, will be deleted
        List<IPowerUp> collectedPowerUps = new List<IPowerUp>();

        foreach (var spawnedPowerUp in powerUps)
        {
            if (IsCollision(alice.Position, spawnedPowerUp))
            {
                spawnedPowerUp.Collect(alice);
                collectedPowerUps.Add(spawnedPowerUp);
            }
        }

        // Remove collected power-ups
        foreach (var collectedPowerUp in collectedPowerUps)
        {
            powerUps.Remove(collectedPowerUp);
        }

        foreach (var enemy in enemies)
        {
            enemy.Update(gameTime);
            enemy.UpdateEnemy(gameTime, alice);
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

        foreach (var enemy in enemies)
        {
            enemy.Draw(spriteBatch);
        }

        spriteBatch.End();
    }

    public virtual void UnloadContent() 
    { 
        //unload level specific content
    }

    //Probably move this somewher else later?
    private bool IsCollision(Vector2 playerPosition, ICollectible collectible)
    {
        Rectangle playerRectangle = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, alice.Width, alice.Height);
        Rectangle collectibleRectangle = new Rectangle((int)collectible.Position.X, (int)collectible.Position.Y, collectible.Width, collectible.Height);

        return playerRectangle.Intersects(collectibleRectangle);
    }
}
