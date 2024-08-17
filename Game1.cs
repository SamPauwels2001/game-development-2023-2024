using System;
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
        private MainScreen mainMenu;
        private List<Button> _buttons;

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

            _buttons = new List<Button>();
        }

        protected override void Initialize()
        {
            currentGameState = GameState.MainMenu; //initial gamestate
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //LoadLevel(currentGameState);
            LoadMainMenu();
        }

        private void LoadMainMenu()
        {
            var backgroundTexture = Content.Load<Texture2D>("AliceBackground");

            var background = new Background(backgroundTexture);

            var button1Texture = Content.Load<Texture2D>("Button1");
            var button2Texture = Content.Load<Texture2D>("Button2");
            var button3Texture = Content.Load<Texture2D>("Button3");

            _buttons.Add(CreateButton(button1Texture, () => TransitionToLevel(GameState.Level1)));
            _buttons.Add(CreateButton(button2Texture, () => TransitionToLevel(GameState.Level2)));
            _buttons.Add(CreateButton(button3Texture, () => TransitionToLevel(GameState.Level3)));

            mainMenu = new MainScreen(background, _buttons);
        }

        private Button CreateButton(Texture2D texture, Action onClick)
        {
            // Calculate button size and position
            int buttonWidth = texture.Width;
            int buttonHeight = texture.Height;

            int offsetX = 75;
            int offsetY = -150;

            int xPosition = (ScreenWidth - buttonWidth) / 2 + offsetX; 
            int yPosition = (ScreenHeight - buttonHeight) / 2 + offsetY;

            // Stack vertically
            yPosition += _buttons.Count * (buttonHeight + 10); // 10 pixels for margin

            var bounds = new Rectangle(xPosition, yPosition, buttonWidth, buttonHeight);
            return new Button(texture, bounds, onClick);
        }

        protected override void Update(GameTime gameTime)
        {            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var mouseState = Mouse.GetState();

            switch (currentGameState)
            {
                case GameState.MainMenu:
                    mainMenu.Update(gameTime, mouseState);
                    break;

                default:
                    currentLevel?.Update(gameTime);
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (currentGameState)
            {
                case GameState.MainMenu:
                    mainMenu.Draw(_spriteBatch);
                    break;

                default:
                    currentLevel?.Draw(gameTime);
                    break;
            }

            base.Draw(gameTime);
        }

        private void TransitionToLevel(GameState newState)
        {
            currentLevel?.UnloadContent();
            currentGameState = newState;
            LoadLevel(newState);
        }

        private void LoadLevel(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Level1:
                    currentLevel = new Level1(this, _spriteBatch, Content);
                    break;
                case GameState.Level2:
                    currentLevel = new Level2(this, _spriteBatch, Content);
                    break;
                case GameState.Level3:
                    currentLevel = new Level3(this, _spriteBatch, Content);
                    break;
            }

            currentLevel?.LoadContent();
        }

        protected override void UnloadContent()
        {            
            currentLevel?.UnloadContent();
            //mainMenu?.UnloadContent();
        }

    }
}