using System;
using Microsoft.Xna.Framework;
using GameDevProject;

public class StayAwayStrategy : IMovementStrategy
{
    private Random random = new Random();
    private float evasionStrength = 0.8f; 
    private float randomMovementStrength = 1.5f;

    private float cooldownTime = 1.0f;
    private float timeSinceLastChange = 0.0f;

    private Vector2 randomOffset = Vector2.Zero;

    public void Move(Enemy enemy, Alice alice, GameTime gameTime)
    {
        timeSinceLastChange += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (timeSinceLastChange >= cooldownTime)
        {
            randomOffset = new Vector2(
                (float)(random.NextDouble() - 0.5) * randomMovementStrength,
                (float)(random.NextDouble() - 0.5) * randomMovementStrength
            );
            timeSinceLastChange = 0.0f;
        }

        Vector2 directionAwayFromAlice = enemy.Position - alice.Position;
        if (directionAwayFromAlice != Vector2.Zero)
        {
            directionAwayFromAlice.Normalize();
        }

        Vector2 movementDirection = directionAwayFromAlice * evasionStrength + randomOffset;

        enemy.Position += movementDirection * enemy.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}
