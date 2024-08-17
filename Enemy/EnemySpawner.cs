using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class EnemySpawner
{
    private EnemyFactory enemyFactory;
    private List<Enemy> enemies;
    private float spawnInterval;
    private float timeSinceLastSpawn;
    private Random random;

    private float difficultyIncreaseRate = 0.95f; // Rate at which the spawn interval decreases
    private float minimumSpawnInterval = 0.5f;

    private int screenWidth;
    private int screenHeight;

    public EnemySpawner(EnemyFactory enemyFactory, List<Enemy> enemies, int screenWidth, int screenHeight, float initialSpawnInterval)
    {
        this.enemyFactory = enemyFactory;
        this.enemies = enemies;
        this.screenWidth = screenWidth;
        this.screenHeight = screenHeight;
        this.spawnInterval = initialSpawnInterval;
        this.timeSinceLastSpawn = 0f;
        this.random = new Random();
    }

    public void Update(GameTime gameTime, Texture2D projectileTexture)
    {
        timeSinceLastSpawn += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemy(projectileTexture);
            timeSinceLastSpawn = 0f;

            spawnInterval = Math.Max(spawnInterval * difficultyIncreaseRate, minimumSpawnInterval);
        }
    }

    private void SpawnEnemy(Texture2D projectileTexture)
    {
        Vector2 spawnPosition = GetRandomEdgePosition();

        int enemyType = random.Next(3);
        Enemy newEnemy;

        switch (enemyType)
        {
            case 0:
                newEnemy = enemyFactory.CreateStayAwayEnemy(spawnPosition, projectileTexture);
                break;
            case 1:
                newEnemy = enemyFactory.CreateMoveCloserEnemy(spawnPosition, projectileTexture);
                break;
            case 2:
                newEnemy = enemyFactory.CreateErraticEnemy(spawnPosition, projectileTexture);
                break;
            default:
                throw new InvalidOperationException("Invalid enemy type.");
        }

        enemies.Add(newEnemy);
    }

    private Vector2 GetRandomEdgePosition()
    {
        int edge = random.Next(4);
        int x, y;

        switch (edge)
        {
            case 0: // Top edge
                x = random.Next(screenWidth);
                y = 0;
                break;
            case 1: // Right edge
                x = screenWidth;
                y = random.Next(screenHeight);
                break;
            case 2: // Bottom edge
                x = random.Next(screenWidth);
                y = screenHeight;
                break;
            case 3: // Left edge
                x = 0;
                y = random.Next(screenHeight);
                break;
            default:
                throw new InvalidOperationException("Invalid edge value.");
        }

        return new Vector2(x, y);
    }
}