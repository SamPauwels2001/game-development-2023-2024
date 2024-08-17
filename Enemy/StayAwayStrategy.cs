using System;
using Microsoft.Xna.Framework;
using GameDevProject;

public class StayAwayStrategy : IMovementStrategy
{
    public void Move(Enemy enemy, Alice alice, GameTime gameTime)
    {
        Vector2 direction = enemy.Position - alice.Position;
        direction.Normalize();
        enemy.Position += direction * enemy.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}
