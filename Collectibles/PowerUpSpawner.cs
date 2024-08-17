using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GameDevProject.Collectibles
{
    public class PowerUpSpawner
    {
        private PowerUpFactory powerUpFactory;
        private Random random;
        private int screenWidth;
        private int screenHeight;

        // Probability settings
        private float spawnChance = 0.005f; // 0.01f is 1% chance per update
        private Dictionary<string, float> powerUpChances;

        public PowerUpSpawner(PowerUpFactory powerUpFactory, int screenWidth, int screenHeight)
        {
            this.powerUpFactory = powerUpFactory;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.random = new Random();

            powerUpChances = new Dictionary<string, float>
        {
            { "tea", 0.4f }, 
            { "boot", 0.1f }, 
            { "watch", 0.15f },
            { "orangemarmalade", 0.4f }
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
}
