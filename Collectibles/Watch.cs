﻿using System;
using GameDevProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Animation;

public class Watch : IPowerUp
{
    private Texture2D texture;
    private Rectangle sourceRectangle;

    public Watch(Texture2D texture, Rectangle sourceRectangle)
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
        //Decrease attack cooldown
        alice.attackCooldown -= 0.2f;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(texture, position, sourceRectangle, Color.White);
    }
}
