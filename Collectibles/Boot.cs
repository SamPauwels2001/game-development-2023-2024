using System;
using GameDevProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Animation;

public class Boot : IPowerUp
{
    private Texture2D texture;
    private Rectangle sourceRectangle;

    public Boot(Texture2D texture, Rectangle sourceRectangle)
    {
        this.texture = texture;
        this.sourceRectangle = sourceRectangle;
    }

    public void Collect(Alice alice)
    {
        ApplyEffect(alice);        
    }

    public void ApplyEffect(Alice alice)
    {
        //increase movement speed by increasing MaxSpeed
        alice.MaxSpeed += 2;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(texture, position, sourceRectangle, Color.White);
    }
}
