using GameDevProject.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework.Input;
using GameDevProject.Input;

namespace GameDevProject
{
    internal class Alice:IGameObject
    {
        Texture2D aliceTexture;
        Animation.Animation aliceAnimation;
        private Vector2 position;
        private Vector2 speed;
        private Vector2 acceleration;
        private SpriteEffects spriteEffect;
        private IInputReader inputReader;
        private int screenWidth;
        private int screenHeight;
        private bool isMoving;

        // Attack-related properties
        private IAttack attack;
        private Texture2D attackTexture;
        //private SoundEffect attackSound;

        public Alice(Texture2D texture, IInputReader inputReader, int screenWidth, int screenHeight)
        {
            aliceTexture = texture;
            this.inputReader = inputReader;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            this.attackTexture = attackTexture;
            //this.attackSound = attackSound;

            // Initialize animation
            aliceAnimation = new Animation.Animation();

            // Initialize Alice position
            int initialX = screenWidth / 2 - 38; // Half of the sprite width (76/2)
            int initialY = screenHeight / 2 - 67; // Half of the sprite height (134/2)
            position = new Vector2(initialX, initialY);

            speed = new Vector2(1, 1);
            acceleration = new Vector2(0.1f, 0.1f);
            spriteEffect = SpriteEffects.None;
        }

        public void Update(GameTime gameTime)
        {
            // Determine if Alice is moving
            Vector2 direction = inputReader.ReadInput();
            isMoving = direction.LengthSquared() > 0;

            // Set animation based on movement state
            if (isMoving)
            {                
                aliceAnimation.AddFrame(new AnimationFrame(new Rectangle(76, 0, 76, 134)));
                aliceAnimation.AddFrame(new AnimationFrame(new Rectangle(152, 0, 76, 134)));
            }
            else
            {
                // Set frame for standing still
                aliceAnimation = new Animation.Animation();
                aliceAnimation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 76, 134)));
            }

            position.X = MathHelper.Clamp(position.X, 0, screenWidth - aliceAnimation.CurrentFrame.SourceRectangle.Width);
            position.Y = MathHelper.Clamp(position.Y, 0, screenHeight - aliceAnimation.CurrentFrame.SourceRectangle.Height);

            aliceAnimation.Update(gameTime);

            Move();

            // Handle attack input
            MouseReader mouseReader = inputReader as MouseReader;
            if (mouseReader != null && mouseReader.IsLeftMouseClick() && (attack == null || !attack.IsActive))
            {
                // Create the attack towards the mouse position
                Vector2 mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                Vector2 attackDirection = mousePosition - position;
                attackDirection.Normalize();

                attack = new BasicAttack(10, attackTexture, position, 2.0f);
                attackDirection *= 10f; // Speed
                attack.SetDirection(attackDirection);
            }

            // Update attack
            if (attack != null && attack.IsActive)
            {
                attack.Update(gameTime);
            }
        }

        public void Attack(IAttackable target)
        {
            if (attack != null && attack.IsActive)
            {
                attack.ExecuteAttack(target);
            }
        }


        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        } 


        private void Move()
        {
            var direction = inputReader.ReadInput();
            direction *= speed;
            position += direction;
            speed += acceleration;
            float maxSpeed = 10;
            speed = Limit(speed, maxSpeed);          
        }


        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(aliceTexture, new Vector(0, 0), aliceAnimation.CurrentFrame.SourceRectangle, Color.White);
            spriteBatch.Draw(aliceTexture, position, aliceAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1f, spriteEffect, 0f);

            // Draw attack
            if (attack != null && attack.IsActive)
            {
                attack.Draw(spriteBatch);
            }
        }

    }
}
