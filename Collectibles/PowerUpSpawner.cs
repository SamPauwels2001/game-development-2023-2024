using System;
using Microsoft.Xna.Framework;

public class PowerUpSpawner
{
    private PowerUpFactory powerUpFactory;
    private Random random;
    private int screenWidth;
    private int screenHeight;

    // Probability settings
    private float spawnChance = 0.10f; // 0.01f is 1% chance per update
    private Dictionary<string, float> powerUpChances;

    public PowerUpSpawner(PowerUpFactory powerUpFactory, int screenWidth, int screenHeight)
    {
        this.powerUpFactory = powerUpFactory;
        this.screenWidth = screenWidth;
        this.screenHeight = screenHeight;
        this.random = new Random();
        
        powerUpChances = new Dictionary<string, float>
        {
            { "tea", 0.5f }, // 50% chance
            { "boot", 0.3f }, // 30% chance
            { "watch", 0.15f }, // 15% chance
            { "orangemarmalade", 0.05f } // 5% chance
        };
    }

    public IPowerUp TrySpawnPowerUp()
    {
        if (random.NextDouble() < spawnChance)
        {
            var powerUpType = GetRandomPowerUpType();
            var powerUp = powerUpFactory.Create(powerUpType) as IPowerUp;

            if (powerUp != null)
            {
                // random location
                var position = new Vector2(
                    random.Next(0, screenWidth),
                    random.Next(0, screenHeight)
                );

                // set position of powerup
                powerUp.SetPosition(position);

                return powerUp;
            }
        }

        return null;
    }

    private string GetRandomPowerUpType()
    {
        var cumulative = 0.0f;
        var roll = (float)random.NextDouble();

        foreach (var entry in powerUpChances)
        {
            cumulative += entry.Value;
            if (roll < cumulative)
            {
                return entry.Key;
            }
        }

        return "tea"; // Default to tea
    }
}
