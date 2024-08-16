using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject;
using Microsoft.Xna.Framework.Content;

public class Level1 : Level
{
    public Level1(Game1 game, SpriteBatch spriteBatch, ContentManager content) 
        : base(game, spriteBatch, content) { }

    public override void LoadContent()
    {
        base.LoadContent();
        // Load level-specific content
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        // Update level 1
    }

    public override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        // Draw level 1
    }

    public override void UnloadContent()
    {
        base.UnloadContent();
        // Unload level-specific content
    }
}
