using System;
using Microsoft.Xna.Framework;
using GameDevProject;

public class MoveCloserStrategy : IMovementStrategy
{
    public void Move(Enemy enemy, Alice alice, GameTime gameTime)
    {
        Vector2 direction = alice.Position - enemy.Position;
        direction.Normalize();
        enemy.Position += direction * enemy.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}
