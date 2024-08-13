using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Interfaces;

public class BasicAttack : IAttack
{
    private int damage;
    private Texture2D texture;
    private Vector2 position;
    //private SoundEffect soundEffect;
    private bool isActive;
    private float duration;
    private float elapsedTime;
    private Vector2 direction;
    public float AttackSpeed { get; set; }
    public int AttackAmount { get; set; }


    public BasicAttack(int damage, Texture2D texture, /*SoundEffect soundEffect,*/ Vector2 position, float duration, float attackSpeed)
    {
        this.damage = damage;
        this.texture = texture;
        this.position = position;
        //this.soundEffect = soundEffect;
        this.duration = duration;
        this.isActive = true;
        this.elapsedTime = 0f;
        this.AttackSpeed = attackSpeed;
        this.AttackAmount = 2;
    }

    public void ExecuteAttack(IAttackable target)
    {
        if (isActive)
        {
            target.TakeDamage(damage);
            //PlaySound();
            //soundEffect.Play();
            isActive = false;
        }
    }

    public void Update(GameTime gameTime)
    {
        //update

        if (!isActive) return;

        elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (elapsedTime >= duration)
        {
            isActive = false;
        }

        position += direction * AttackSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (isActive)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }

    public bool IsActive => isActive;

}
