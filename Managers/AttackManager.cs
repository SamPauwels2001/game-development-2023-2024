using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameDevProject.Input;
using System.Collections.Generic;
using GameDevProject.Interfaces;

namespace GameDevProject.Managers
{
    public class AttackManager
    {
        private List<IAttack> attacks;
        private Texture2D attackTexture;
        private IInputReader mouseReader;
        private float attackSpeed = 250f; // Default attack speed
        private float attackCooldown = 0.2f;
        private float lastAttackTime = 0f;

        public AttackManager(Texture2D attackTexture, IInputReader mouseReader)
        {
            this.attackTexture = attackTexture;
            this.mouseReader = mouseReader;
            attacks = new List<IAttack>();
        }

        public void Update(GameTime gameTime, Vector2 alicePosition)
        {
            lastAttackTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (mouseReader is MouseReader mouse)
            {
                // Debug: Check if the mouse click is being detected
                if (mouse.IsLeftMouseClick())
                {
                    Console.WriteLine("Left Mouse Click detected.");
                }

                if (mouse.IsLeftMouseClick() && attacks.Count < 2 && lastAttackTime >= attackCooldown)
                {
                    Vector2 mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                    Vector2 attackDirection = mousePosition - alicePosition;
                    attackDirection.Normalize();

                    var attack = new BasicAttack(10, attackTexture, alicePosition, 2.0f, attackSpeed);
                    attack.SetDirection(attackDirection);
                    attacks.Add(attack);

                    lastAttackTime = 0f;
                }
            }

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
                if (attack.IsActive)
                {
                    attack.Draw(spriteBatch);
                }
            }
        }
    }
}
