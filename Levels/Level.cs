using System;
using Microsoft.Xna.Framework;
using GameDevProject;

public abstract class Level
{
    protected Game1 game;

    public Level(Game1 game)
    {
        this.game = game;
    }

    public virtual void LoadContent() { }
    public virtual void Update(GameTime gameTime) { }
    public virtual void Draw(GameTime gameTime) { }
    public virtual void UnloadContent() { }
}
