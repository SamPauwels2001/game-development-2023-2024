using System;
using Microsoft.Xna.Framework;
using GameDevProject;

public class ErraticMovementStrategy : IMovementStrategy
{
    private Random random = new Random();

    public void Move(Enemy enemy, Alice alice, GameTime gameTime)
    {
        Vector2 direction = new Vector2((float)(random.NextDouble() - 0.5), (float)(random.NextDouble() - 0.5));
        direction.Normalize();
        enemy.Position += direction * enemy.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}