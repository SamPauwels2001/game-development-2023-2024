using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject;
using GameDevProject.Interfaces;
using GameDevProject.Managers;
using GameDevProject.Collectibles;

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

    private ItemFactory itemFactory;
    private Action<IItem> onItemDrop;

    public int Width => texture.Width;
    public int Height => texture.Height;

    public bool IsActive { get; private set; } = true;

    public Enemy(Texture2D texture, IMovementStrategy strategy, Texture2D projectileTexture, ItemFactory itemFactory, Action<IItem> onItemDrop)
    {
        this.texture = texture;
        this.movementStrategy = strategy;
        this.projectileTexture = projectileTexture;
        this._attackFactory = new EnemyAttackFactory();
        this.attackManager = new AttackManager();
        this.itemFactory = itemFactory;
        this.onItemDrop = onItemDrop;
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
        TryDropItem();
    }

    private void TryDropItem()
    {
        Random random = new Random();
        double dropChance = random.NextDouble();

        if (dropChance < 0.6) // 60% chance for Potion
        {
            IItem potion = itemFactory.Create("potion");
            potion.Position = Position;
            onItemDrop?.Invoke(potion);
        }
        else if (dropChance < 0.9) // 30% chance for Cake after 60% chance for Potion
        {
            IItem cake = itemFactory.Create("cake");
            cake.Position = Position;
            onItemDrop?.Invoke(cake);
        }
    }

}
