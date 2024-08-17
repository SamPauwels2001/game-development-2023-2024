using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using GameDevProject.Interfaces;

namespace GameDevProject.Managers
{
    public class AttackManager
    {
        public List<IAttack> attacks;

        public AttackManager()
        {
            attacks = new List<IAttack>();
        }

        public void AddAttack(IAttack attack)
        {
            attacks.Add(attack);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = attacks.Count - 1; i >= 0; i--)
            {
                attacks[i].Update(gameTime);
                if (!attacks[i].IsActive)
                {
                    attacks.RemoveAt(i);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var attack in attacks)
            {
                attack.Draw(spriteBatch);
            }
        }
    }
}

