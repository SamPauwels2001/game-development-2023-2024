using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Interfaces;

namespace GameDevProject
{
    public class BasicAttack : IAttack
    {
        protected int damage;
        protected Texture2D texture;
        protected Vector2 position;
        protected bool isActive;
        protected float elapsedTime;
        protected Vector2 direction;
        public float AttackSpeed { get; set; }

        public BasicAttack(int damage, Texture2D texture, Vector2 position, float attackSpeed)
        {
            this.damage = damage;
            this.texture = texture;
            this.position = position;
            this.isActive = true;
            this.elapsedTime = 0f;
            this.AttackSpeed = attackSpeed;
        }

        public virtual void ExecuteAttack(IAttackable target)
        {
            if (isActive)
            {
                target.TakeDamage(damage);
                isActive = false;
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!isActive) return;

            position += direction * AttackSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (position.X < 0 || position.X > Game1.ScreenWidth || position.Y < 0 || position.Y > Game1.ScreenHeight)
            {
                isActive = false;
            }

        }

        public void SetDirection(Vector2 direction)
        {
            this.direction = direction;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (isActive)
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
        }

        public bool IsActive => isActive;
    }
}
