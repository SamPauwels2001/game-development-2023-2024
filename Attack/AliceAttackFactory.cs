using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Interfaces;

public class AliceAttackFactory : IAttackFactory
{
    private Texture2D _attackTexture;

    public AliceAttackFactory(Texture2D attackTexture)
    {
        _attackTexture = attackTexture;
    }

    public IAttack CreateProjectileAttack(Vector2 position, Vector2 direction)
    {
        return new ProjectileAttack(_attackTexture, position, direction, 5f); // speed 5f for now idk
    }
}
