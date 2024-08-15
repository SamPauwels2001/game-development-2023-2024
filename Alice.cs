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
using GameDevProject.Managers;

namespace GameDevProject
{
    internal class Alice : IGameObject, IMovable /*,IAttackable*/
    {
        Texture2D aliceTexture;
        Animation.Animation aliceAnimation;
        private SpriteEffects spriteEffect;

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public float MaxSpeed { get; set; }
        public Vector2 Acceleration { get; set; }

        public IInputReader KeyboardReader { get; set; }
        private IInputReader mouseReader;
        private bool isMoving;

        private int screenWidth;
        private int screenHeight;

        private IAttackFactory _attackFactory;
        private AttackManager attackManager;
        private MovementManager movementManager;        

        public Alice(Texture2D texture, Texture2D attackTexture, IInputReader keyboardReader, IInputReader mouseReader)
        {
            aliceTexture = texture;
            KeyboardReader = keyboardReader; // IMovable property
            this.mouseReader = mouseReader;
            this.screenWidth = Game1.ScreenWidth;
            this.screenHeight = Game1.ScreenHeight;

            // Initialize animation
            aliceAnimation = new Animation.Animation();

            // Initialize Alice position
            int initialX = screenWidth / 2 - 38; // Half of the sprite width (76/2)
            int initialY = screenHeight / 2 - 67; // Half of the sprite height (134/2)
            Position = new Vector2(initialX, initialY);

            Speed = new Vector2(1, 1);
            MaxSpeed = 8;
            Acceleration = new Vector2(0.1f, 0.1f);
            spriteEffect = SpriteEffects.None;

            _attackFactory = new AliceAttackFactory(attackTexture);
            attackManager = new AttackManager();
            movementManager = new MovementManager();
        }

        public void Update(GameTime gameTime)
        {
            // Determine if Alice is moving
            Vector2 direction = KeyboardReader.ReadInput();
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

            Position = new Vector2(
                MathHelper.Clamp(Position.X, 0, screenWidth - aliceAnimation.CurrentFrame.SourceRectangle.Width),
                MathHelper.Clamp(Position.Y, 0, screenHeight - aliceAnimation.CurrentFrame.SourceRectangle.Height)
            );

            aliceAnimation.Update(gameTime);
            Move();
        }        

        private void Move()
        {
            movementManager.Move(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(aliceTexture, Position, aliceAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1f, spriteEffect, 0f);

            attackManager.Draw(spriteBatch);
        }
    }
}
