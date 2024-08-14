﻿using Microsoft.Xna.Framework;
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
        public int AttackAmount { get; set; } = 5;

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
                if (mouse.IsLeftMouseClick() && lastAttackTime >= attackCooldown && attacks.Count < AttackAmount)
                {
                    Vector2 attackStartPosition = alicePosition + new Vector2(38, 67); // Center of Alice sprite

                    Vector2 mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                    Vector2 attackDirection = mousePosition - attackStartPosition;
                    attackDirection.Normalize();

                    var attack = new BasicAttack(10, attackTexture, attackStartPosition, attackSpeed);
                    attack.SetDirection(attackDirection);
                    attacks.Add(attack);

                    lastAttackTime = 0f; // Reset cooldown timer
                }
            }

            // Update existing attacks
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
