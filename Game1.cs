using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameDevProject.Input;
using System.Collections.Generic;
using GameDevProject.Interfaces;
using GameDevProject;

namespace GameDevProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private GameState currentGameState;
        private Level currentLevel;

        public static int ScreenWidth { get; private set; }
        public static int ScreenHeight { get; private set; }

        Texture2D aliceTexture;
        Texture2D attackBubbleTexture;
        Texture2D itemTexture;

        Alice alice;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //resolution
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            ScreenWidth = _graphics.PreferredBackBufferWidth;
            ScreenHeight = _graphics.PreferredBackBufferHeight;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //load sprites
            aliceTexture = Content.Load<Texture2D>("AliceSprite");
            attackBubbleTexture = Content.Load<Texture2D>("AttackBubble");
            itemTexture = Content.Load<Texture2D>("ItemsSprite");
            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            alice = new Alice(aliceTexture, attackBubbleTexture, new KeyboardReader(), new MouseReader());
        }

        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            alice.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            alice.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void LoadLevel(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Level1:
                    currentLevel = new Level1(this);
                    break;
                case GameState.Level2:
                    //currentLevel = new Level2(this);
                    break;
                case GameState.Level3:
                    //currentLevel = new Level3(this);
                    break;
            }

            currentLevel?.LoadContent();
        }

        protected override void UnloadContent()
        {            
            currentLevel?.UnloadContent();
        }

    }
}