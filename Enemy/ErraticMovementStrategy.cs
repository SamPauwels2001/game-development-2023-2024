using System;
using Microsoft.Xna.Framework;
using GameDevProject;

public class ErraticMovementStrategy : IMovementStrategy
{
    private Random random = new Random();
    private Vector2 direction;
    private float changeDirectionCooldown = 2.0f;
    private float timeSinceLastChange = 0f;

    public void Move(Enemy enemy, Alice alice, GameTime gameTime)
    {
        timeSinceLastChange += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (timeSinceLastChange >= changeDirectionCooldown)
        {
            direction = new Vector2((float)(random.NextDouble() - 0.5), (float)(random.NextDouble() - 0.5));
            direction.Normalize();
            timeSinceLastChange = 0f;
        }

        enemy.Position += direction * enemy.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}