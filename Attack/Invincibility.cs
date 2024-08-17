using System;
using Microsoft.Xna.Framework;

namespace GameDevProject.Attack
{
    public class Invincibility
    {
        private Alice alice;
        private float invincibilityDuration;
        private float elapsedTime;
        private bool isActive;

        public Invincibility(Alice alice)
        {
            this.alice = alice;
        }

        public void Activate(float duration)
        {
            invincibilityDuration = duration;
            elapsedTime = 0f;
            isActive = true;
        }

        public void Update(GameTime gameTime)
        {
            if (isActive)
            {
                elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

                // Flickering
                if (elapsedTime % 0.2f < 0.1f)
                {
                    alice.SetVisible(false);
                }
                else
                {
                    alice.SetVisible(true);
                }

                // Deactivate invincibility
                if (elapsedTime >= invincibilityDuration)
                {
                    isActive = false;
                    alice.SetVisible(true);
                }
            }
        }

        public bool IsActive()
        {
            return isActive;
        }
    }
}