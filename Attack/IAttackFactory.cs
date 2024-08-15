using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Interfaces;

public interface IAttackFactory
{
    IAttack CreateProjectile(Texture2D texture, Vector2 position, Vector2 direction, float speed);
}
