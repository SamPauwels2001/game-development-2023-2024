﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject;
using GameDevProject.Interfaces;
using GameDevProject.Managers;

public class Enemy : IGameObject, IAttackable
{
    public Vector2 Position { get; set; }
    public float Speed { get; set; }
    private IMovementStrategy movementStrategy;

    private Texture2D texture;

    private IAttackFactory _attackFactory;
    private AttackManager attackManager;
    private Texture2D projectileTexture;
    private float attackSpeed = 500f;

    private float attackCooldown = 1.5f;
    private float timeSinceLastAttack = 1.0f;

    public int Width => texture.Width;
    public int Height => texture.Height;

    public bool IsActive { get; private set; } = true;

    public Enemy(Texture2D texture, IMovementStrategy strategy, Texture2D projectileTexture)
    {
        this.texture = texture;
        this.movementStrategy = strategy;
        this.projectileTexture = projectileTexture;
        this._attackFactory = new EnemyAttackFactory();
        this.attackManager = new AttackManager();
    }

    public void Update(GameTime gameTime)
    {
        if (IsActive)
        {
            attackManager.Update(gameTime);
        }
    }

    public void UpdateEnemy(GameTime gameTime, Alice alice)
    {
        if (!IsActive) return;

        movementStrategy.Move(this, alice, gameTime);
        KeepWithinBounds();

        timeSinceLastAttack += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (timeSinceLastAttack >= attackCooldown)
        {
            ShootAtAlice(alice);
            timeSinceLastAttack = 0.0f;
        }

        CollisionManager.CheckProjectileCollisions(alice, attackManager);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (IsActive)
        {
            spriteBatch.Draw(texture, Position, Color.White);
            attackManager.Draw(spriteBatch);
        }
    }

    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        this.movementStrategy = strategy;
    }

    private void KeepWithinBounds()
    {
        Position = new Vector2(
            MathHelper.Clamp(Position.X, 0, Game1.ScreenWidth - texture.Width),
            MathHelper.Clamp(Position.Y, 0, Game1.ScreenHeight - texture.Height)
        );
    }

    private void ShootAtAlice(Alice alice)
    {
        Vector2 direction = alice.Position - Position;
        direction.Normalize();

        var attack = _attackFactory.CreateProjectile(projectileTexture, Position, direction, attackSpeed);
        attackManager.AddAttack(attack);
    }

    public void TakeDamage()
    {
        IsActive = false;
    }

}
