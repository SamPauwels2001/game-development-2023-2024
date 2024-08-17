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
    public class Alice : IGameObject, IMovable ,IAttackable
    {
        Texture2D aliceTexture;
        Texture2D projectileAttackTexture;
        Animation.Animation aliceAnimation;
        private SpriteEffects spriteEffect;

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public float MaxSpeed { get; set; }
        public Vector2 Acceleration { get; set; }

        public Score PlayerScore { get; private set; }
        public int Lives { get; private set; } = 3;
        public Texture2D HeartTexture { get; set; }

        public IInputReader KeyboardReader { get; set; }
        private IInputReader mouseReader;
        private bool isMoving;

        public float attackCooldown = 0.8f;
        private float timeSinceLastAttack = 0.0f;
        public float attackSpeed = 200f;

        private int screenWidth;
        private int screenHeight;

        public int Width => aliceAnimation.CurrentFrame.SourceRectangle.Width;
        public int Height => aliceAnimation.CurrentFrame.SourceRectangle.Height;

        private IAttackFactory _attackFactory;
        private AttackManager attackManager;
        private MovementManager movementManager;        

        public Alice(Texture2D texture, Texture2D attackTexture, IInputReader keyboardReader, IInputReader mouseReader)
        {
            aliceTexture = texture;
            projectileAttackTexture = attackTexture;
            KeyboardReader = keyboardReader; // IMovable property
            this.mouseReader = mouseReader;
            this.screenWidth = Game1.ScreenWidth;
            this.screenHeight = Game1.ScreenHeight;

            // Initialize animation
            aliceAnimation = new Animation.Animation();
            aliceAnimation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 76, 134)));

            // Initialize Alice position
            int initialX = screenWidth / 2 - 38; // Half of the sprite width (76/2)
            int initialY = screenHeight / 2 - 67; // Half of the sprite height (134/2)
            Position = new Vector2(initialX, initialY);
            spriteEffect = SpriteEffects.None;

            //Initialize score
            PlayerScore = new Score();

            //Movement
            Speed = new Vector2(1, 1);
            MaxSpeed = 8;
            Acceleration = new Vector2(0.1f, 0.1f);            

            //Attack
            timeSinceLastAttack = attackCooldown;

            _attackFactory = new AliceAttackFactory();
            attackManager = new AttackManager();
            movementManager = new MovementManager();
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastAttack += (float)gameTime.ElapsedGameTime.TotalSeconds;

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
            HandleMouseClickAttack();
            attackManager.Update(gameTime);
        }

        private void HandleMouseClickAttack()
        {
           if (timeSinceLastAttack >= attackCooldown)
           {
                if (((MouseReader)mouseReader).IsLeftMouseClick())
                {
                    // Calculate center of Alice sprite
                    Vector2 aliceCenter = new Vector2(Position.X + 38, Position.Y + 67);

                    // Calculate direction
                    Vector2 mousePosition = mouseReader.ReadInput();
                    Vector2 direction = mousePosition - aliceCenter;
                    direction.Normalize();

                    // Attack
                    var attack = _attackFactory.CreateProjectile(projectileAttackTexture, aliceCenter, direction, attackSpeed);
                    attackManager.AddAttack(attack);
                    timeSinceLastAttack = 0.0f;
                }
           }
        }

        private void Move()
        {
            movementManager.Move(this);
        }

        public void TakeDamage()
        {
            if (Lives > 0)
            {
                Lives--;
            }
        }

        public void DrawLives(SpriteBatch spriteBatch, Texture2D heartTexture)
        {
            int heartWidth = heartTexture.Width;
            int spacing = 10;

            for (int i = 0; i < Lives; i++)
            {
                spriteBatch.Draw(heartTexture, new Vector2(10 + i * (heartWidth + spacing), 10), Color.White);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (aliceAnimation.CurrentFrame != null)
            {
                spriteBatch.Draw(aliceTexture, Position, aliceAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1f, spriteEffect, 0f);
            }

            DrawLives(spriteBatch, HeartTexture);

            attackManager.Draw(spriteBatch);
        }
    }
}
