using System;
using Microsoft.Xna.Framework;
using GameDevProject;
using Microsoft.Xna.Framework.Graphics;

public class EnemyFactory
{
    private Texture2D enemyTexture;

    public EnemyFactory(Texture2D texture)
    {
        this.enemyTexture = texture;
    }

    public Enemy CreateStayAwayEnemy(Vector2 position, Texture2D projectileTexture)
    {
        return new Enemy(enemyTexture, new StayAwayStrategy(), projectileTexture)
        {
            Position = position,
            Speed = 300f
        };
    }

    public Enemy CreateMoveCloserEnemy(Vector2 position, Texture2D projectileTexture)
    {
        return new Enemy(enemyTexture, new MoveCloserStrategy(), projectileTexture)
        {
            Position = position,
            Speed = 175f
        };
    }

    public Enemy CreateErraticEnemy(Vector2 position, Texture2D projectileTexture)
    {
        return new Enemy(enemyTexture, new ErraticMovementStrategy(), projectileTexture)
        {
            Position = position,
            Speed = 350f
        };
    }
}
