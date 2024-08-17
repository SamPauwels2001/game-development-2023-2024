using System;
using GameDevProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Animation;

namespace GameDevProject.Collectibles
{
    public class ItemFactory : ICollectibleFactory
    {
        private Texture2D itemTexture;

        public ItemFactory(Texture2D itemTexture)
        {
            this.itemTexture = itemTexture;
        }

        public ICollectible Create(string type)
        {
            return type switch
            {
                "cake" => new Cake(itemTexture, new Rectangle(1, 1, 22, 21)),
                "potion" => new Potion(itemTexture, new Rectangle(28, 1, 9, 15)),
            };
        }
    }
}
