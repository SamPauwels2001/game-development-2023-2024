using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Interfaces;

public class EnemyAttackFactory : IAttackFactory
{
    //private Texture2D _attackTexture;

    public EnemyAttackFactory()
    {
        //_attackTexture = attackTexture;
    }

    public IAttack CreateProjectile(Texture2D texture, Vector2 position, Vector2 direction, float speed)
    {
        return new ProjectileAttack(texture, position, direction, speed);
    }
}
