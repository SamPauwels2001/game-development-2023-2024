using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Interfaces;

public class BasicAttack : IAttack
{
    private int damage;
    private Texture2D texture;
    private Vector2 position;

    public BasicAttack(int damage)
    {
        this.damage = damage;
        this.texture = texture;
        this.position = position;
    }

    public void ExecuteAttack(IAttackable target)
    {
        target.TakeDamage(damage);
    }

    public void Update(GameTime gameTime)
    {
        //update
    }

    public void Draw(SpriteBatch spriteBatch)
    {        
        spriteBatch.Draw(texture, position, Color.White);
    }

}
