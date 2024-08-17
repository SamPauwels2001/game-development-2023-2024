using System;
using GameDevProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Animation;

namespace GameDevProject.Collectibles
{
    public class PowerUpFactory : ICollectibleFactory
    {
        private Texture2D itemTexture;

        public PowerUpFactory(Texture2D itemTexture)
        {
            this.itemTexture = itemTexture;
        }

        public ICollectible Create(string type)
        {
            return type switch
            {
                "tea" => new Tea(itemTexture, new Rectangle(27, 26, 25, 18)),
                "watch" => new Watch(itemTexture, new Rectangle(63, 1, 12, 17)),
                "boot" => new Boot(itemTexture, new Rectangle(1, 27, 21, 26)),
                "orangemarmalade" => new OrangeMarmalade(itemTexture, new Rectangle(44, 1, 14, 15)),
                _ => null
            };
        }
    }
}
