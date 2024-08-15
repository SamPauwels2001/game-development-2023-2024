using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using GameDevProject.Interfaces;

namespace GameDevProject.Managers
{
    public class AttackManager
    {
        private List<IAttack> _attacks;

        public AttackManager()
        {
            _attacks = new List<IAttack>();
        }

        public void AddAttack(IAttack attack)
        {
            _attacks.Add(attack);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = _attacks.Count - 1; i >= 0; i--)
            {
                _attacks[i].Update(gameTime);
                if (!_attacks[i].IsActive)
                {
                    _attacks.RemoveAt(i);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var attack in _attacks)
            {
                attack.Draw(spriteBatch);
            }
        }
    }
}

