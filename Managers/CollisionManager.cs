using Microsoft.Xna.Framework;
using System.Collections.Generic;
using GameDevProject.Interfaces;

namespace GameDevProject.Managers
{
    public static class CollisionManager
    {
        public static void CheckProjectileCollisions(IAttackable attackableEntity, AttackManager attackManager)
        {
            Rectangle attackableRect = new Rectangle((int)attackableEntity.Position.X, (int)attackableEntity.Position.Y, attackableEntity.Width, attackableEntity.Height);

            for (int i = attackManager.attacks.Count - 1; i >= 0; i--)
            {
                var attack = attackManager.attacks[i];
                Rectangle attackRect = new Rectangle((int)attack.Position.X, (int)attack.Position.Y, attack.Width, attack.Height);

                if (attackRect.Intersects(attackableRect))
                {
                    attackableEntity.TakeDamage();
                    attack.Deactivate();
                }
            }
        }

        public static bool CheckBlockCollisions(IMovable movable, List<Block> blocks)
        {
            Rectangle movableRect = new Rectangle((int)movable.Position.X, (int)movable.Position.Y, movable.Width, movable.Height);

            foreach (var block in blocks)
            {
                if (!block.Passable && block.CheckCollision(movableRect))
                {
                    return true; // Collision detected
                }
            }

            return false;
        }
    }
}
