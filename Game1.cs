using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameDevProject.Input;
using System.Collections.Generic;
using GameDevProject.Interfaces;

namespace GameDevProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //private IGameScreen _currentScreen;

        Texture2D aliceTexture;
        Texture2D attackTexture;
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
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            /*
            //load main screen
            var background = new Background(Content.Load<Texture2D>("background"));

            var button1 = new Button(Content.Load<Texture2D>("button"), new Rectangle(100, 100, 200, 50), () => LoadLevel(1));
            var button2 = new Button(Content.Load<Texture2D>("button"), new Rectangle(100, 200, 200, 50), () => LoadLevel(2));
            var button3 = new Button(Content.Load<Texture2D>("button"), new Rectangle(100, 300, 200, 50), () => LoadLevel(3));

            _currentScreen = new MainScreen(background, new List<Button> { button1 });
            */

            //load sprites
            aliceTexture = Content.Load<Texture2D>("AliceSprite");
            attackTexture = Content.Load<Texture2D>("AttackBubbleSprite");

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            int screenWidth = _graphics.PreferredBackBufferWidth;
            int screenHeight = _graphics.PreferredBackBufferHeight;

            alice = new Alice(aliceTexture, new KeyboardReader(), new MouseReader(), screenWidth, screenHeight);
            alice.SetAttackTexture(attackTexture);
        }

        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //var mouseState = Mouse.GetState();
            //_currentScreen.Update(gameTime, mouseState);

            // TODO: Add your update logic here

            alice.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            /*_spriteBatch.Begin();
            _currentScreen.Draw(_spriteBatch);
            _spriteBatch.End();*/

            _spriteBatch.Begin();
            alice.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        /*
        private void LoadLevel(int levelNumber)
        {
            // Logic to load the selected level
        } */


    }
}