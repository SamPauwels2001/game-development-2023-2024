using System;
using GameDevProject;
using Microsoft.Xna.Framework;

public interface IMovementStrategy
{
    void Move(Enemy enemy, Alice alice, GameTime gameTime);
}
