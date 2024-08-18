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
    private EnemySpawner enemySpawner;
    private List<IItem> droppedItems;

    private SpriteFont scoreFont;

    protected Texture2D tileSet;
    protected Rectangle grassSourceRectangle;
    protected Rectangle sandSourceRectangle;
    protected Rectangle bushSourceRectangle;
    protected Rectangle flowerSourceRectangle;
    protected Rectangle rockSourceRectangle;
    protected Rectangle fenceSourceRectangle;
    protected Rectangle barrelSourceRectangle;

    protected Block[,] gameBoard;
    protected Block[,] detailBoard;

    public Level(Game1 game, SpriteBatch spriteBatch, ContentManager content)
    {
        this.game = game;
        this.spriteBatch = spriteBatch;
        this.content = content;
        powerUps = new List<IPowerUp>();

        enemies = new List<Enemy>();
        droppedItems = new List<IItem>();
    }

    public virtual void LoadContent() 
    {
        var aliceTexture = content.Load<Texture2D>("AliceSprite");
        var attackBubbleTexture = content.Load<Texture2D>("AttackBubble");
        var enemyProjectileTexture = content.Load<Texture2D>("EnemyProjectile");
        var heartTexture = content.Load<Texture2D>("Heart");
        var itemTexture = content.Load<Texture2D>("ItemsSprite");

        scoreFont = content.Load<SpriteFont>("Score");

        tileSet = content.Load<Texture2D>("TileSet");
        grassSourceRectangle = new Rectangle(162, 161, 64, 64);
        sandSourceRectangle = new Rectangle(192, 240, 48, 48);
        bushSourceRectangle = new Rectangle(434, 150, 42, 38);
        flowerSourceRectangle = new Rectangle(300, 196, 26, 26);
        rockSourceRectangle = new Rectangle(434, 202, 44, 34);
        fenceSourceRectangle = new Rectangle(784, 198, 114, 40);
        barrelSourceRectangle = new Rectangle(484, 244, 40, 44);

        List<Block> allBlocks = GetAllBlocks();

        alice = new Alice(aliceTexture, attackBubbleTexture, new KeyboardReader(), new MouseReader(), scoreFont, allBlocks);
        alice.HeartTexture = heartTexture;

        var itemFactory = new ItemFactory(itemTexture);
        var powerUpFactory = new PowerUpFactory(itemTexture);

        powerUpSpawner = new PowerUpSpawner(powerUpFactory, Game1.ScreenWidth, Game1.ScreenHeight);

        Action<IItem> itemDropCallback = item => droppedItems.Add(item);

        var enemyTexture = content.Load<Texture2D>("Card");
        var enemyFactory = new EnemyFactory(enemyTexture, itemFactory, itemDropCallback);
        enemySpawner = new EnemySpawner(enemyFactory, enemies, Game1.ScreenWidth, Game1.ScreenHeight, initialSpawnInterval: 5.0f);
    }

    public virtual void Update(GameTime gameTime) 
    {
        alice.Update(gameTime);
        alice.UpdateAliceCollisions(gameTime, enemies);

        var powerUp = powerUpSpawner.TrySpawnPowerUp();
        if (powerUp != null)
        {
            powerUps.Add(powerUp);
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

        var enemyProjectileTexture = content.Load<Texture2D>("EnemyProjectile");
        enemySpawner.Update(gameTime, enemyProjectileTexture);

        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i].IsActive)
            {
                enemies[i].Update(gameTime);
                enemies[i].UpdateEnemy(gameTime, alice);
            }
            else
            {
                enemies.RemoveAt(i);
            }
        }

        // Handle item collection
        List<IItem> collectedItems = new List<IItem>();
        foreach (var item in droppedItems)
        {
            if (IsCollision(alice.Position, item))
            {
                item.Collect(alice);
                collectedItems.Add(item);
            }
        }
        foreach (var collectedItem in collectedItems)
        {
            droppedItems.Remove(collectedItem);
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

        foreach (var item in droppedItems)
        {
            item.Draw(spriteBatch);
        }

        spriteBatch.End();
    }

    public virtual void UnloadContent() 
    { 
        //unload level specific content
    }

    private void HandleItemDrop(IItem item)
    {
        droppedItems.Add(item);
    }

    //Probably move this somewher else later?
    private bool IsCollision(Vector2 playerPosition, ICollectible collectible)
    {
        Rectangle playerRectangle = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, alice.Width, alice.Height);
        Rectangle collectibleRectangle = new Rectangle((int)collectible.Position.X, (int)collectible.Position.Y, collectible.Width, collectible.Height);

        return playerRectangle.Intersects(collectibleRectangle);
    }

    //list of blocks for collisions
    protected virtual List<Block> GetAllBlocks()
    {
        List<Block> allBlocks = new List<Block>();

        if (gameBoard != null)
        {
            // Iterate over the gameBoard 2D array
            foreach (var block in gameBoard)
            {
                allBlocks.Add(block);
            }
        }

        if (detailBoard != null)
        {
            // Iterate over the detailBoard 2D array
            foreach (var block in detailBoard)
            {
                allBlocks.Add(block);
            }
        }

        return allBlocks;
    }
}
