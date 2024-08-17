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

    public Enemy CreateStayAwayEnemy(Vector2 position)
    {
        var enemy = new Enemy(enemyTexture, new StayAwayStrategy());
        enemy.Position = position;
        enemy.Speed = 300f;
        return enemy;
    }

    public Enemy CreateMoveCloserEnemy(Vector2 position)
    {
        var enemy = new Enemy(enemyTexture, new MoveCloserStrategy());
        enemy.Position = position;
        enemy.Speed = 175f;
        return enemy;
    }

    public Enemy CreateErraticEnemy(Vector2 position)
    {
        var enemy = new Enemy(enemyTexture, new ErraticMovementStrategy());
        enemy.Position = position;
        enemy.Speed = 350f;
        return enemy;
    }
}
