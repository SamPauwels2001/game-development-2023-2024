using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Interfaces;

public class AliceAttackFactory : IAttackFactory
{
    //private Texture2D _attackTexture;

    public AliceAttackFactory()
    {
        //_attackTexture = attackTexture;
    }

    public IAttack CreateProjectile(Texture2D attackTexture, Vector2 position, Vector2 direction, float speed)
    {
        return new ProjectileAttack(attackTexture, position, direction, speed);
    }
}
