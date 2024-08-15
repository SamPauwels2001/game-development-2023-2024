using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Interfaces;

public class EnemyAttackFactory : IAttackFactory
{
    private Texture2D _attackTexture;

    public EnemyAttackFactory(Texture2D attackTexture)
    {
        _attackTexture = attackTexture;
    }

    public IAttack CreateProjectile(Vector2 position, Vector2 direction)
    {
        return new ProjectileAttack(_attackTexture, position, direction, 3f); // 3f = speed for enemies for now
    }
}
