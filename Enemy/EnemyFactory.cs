using System;
using Microsoft.Xna.Framework;
using GameDevProject;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Collectibles;

public class EnemyFactory
{
    private Texture2D enemyTexture;
    private ItemFactory itemFactory;
    private Action<IItem> itemDropCallback;

    public EnemyFactory(Texture2D texture, ItemFactory itemFactory, Action<IItem> itemDropCallback)
    {
        this.enemyTexture = texture;
        this.itemFactory = itemFactory;
        this.itemDropCallback = itemDropCallback;
    }

    public Enemy CreateStayAwayEnemy(Vector2 position, Texture2D projectileTexture)
    {
        return new Enemy(enemyTexture, new StayAwayStrategy(), projectileTexture, itemFactory, itemDropCallback)
        {
            Position = position,
            Speed = 300f
        };
    }

    public Enemy CreateMoveCloserEnemy(Vector2 position, Texture2D projectileTexture)
    {
        return new Enemy(enemyTexture, new StayAwayStrategy(), projectileTexture, itemFactory, itemDropCallback)
        {
            Position = position,
            Speed = 175f
        };
    }

    public Enemy CreateErraticEnemy(Vector2 position, Texture2D projectileTexture)
    {
        return new Enemy(enemyTexture, new StayAwayStrategy(), projectileTexture, itemFactory, itemDropCallback)
        {
            Position = position,
            Speed = 350f
        };
    }
}
