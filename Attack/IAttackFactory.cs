using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface IAttackFactory
{
    IAttack CreateProjectile(Vector2 position, Vector2 direction);
}
