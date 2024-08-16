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
            currentGameState = GameState.Level1; //initial gamestate
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            LoadLevel(currentGameState);            
        }

        protected override void Update(GameTime gameTime)
        {            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            /*switch (currentGameState)
            {
                case GameState.MainMenu:
                    if ( //start level )
                    {
                        TransitionToLevel(GameState.Level1);
                    }
                    break;

                case GameState.GameOver:
                    // handle game over
                    // back to main menu
                    break;
            }*/

            currentLevel?.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            currentLevel?.Draw(gameTime);
            base.Draw(gameTime);
        }

        private void LoadLevel(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Level1:
                    currentLevel = new Level1(this, _spriteBatch, Content);
                    break;
                case GameState.Level2:
                    //currentLevel = new Level2(this, _spriteBatch, Content);
                    break;
                case GameState.Level3:
                    //currentLevel = new Level3(this, _spriteBatch, Content);
                    break;
            }

            currentLevel?.LoadContent();
        }

        private void TransitionToLevel(GameState newState)
        {
            currentLevel?.UnloadContent();
            currentGameState = newState;
            LoadLevel(newState);
        }

        protected override void UnloadContent()
        {            
            currentLevel?.UnloadContent();
        }

    }
}