using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Animation
{
    public class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }

        private List<AnimationFrame> frames;

        private int counter;
        private double secondCounter = 0;
        private int fps = 5;

        //private double frameMovement = 0;


        public Animation()
        {
            frames = new List<AnimationFrame>();
            counter = 0;
        }

        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            if (frames.Count == 1)
            {
                CurrentFrame = frames[0];
            }
        }

        public void Update(GameTime gameTime)
        {
            if (frames.Count == 0) return;

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;

            //frameMovement += CurrentFrame.SourceRectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;
            /* if (frameMovement >= CurrentFrame.SourceRectangle.Width)
            {
                counter++;
                frameMovement = 0;
            } */

            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }

            CurrentFrame = frames[counter];
        }

    }
}