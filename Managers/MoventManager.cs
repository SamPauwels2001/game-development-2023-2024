using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameDevProject.Input;
using System.Collections.Generic;
using GameDevProject.Interfaces;

namespace GameDevProject.Managers
{
    class MovementManager
    {
        private List<Block> blocks;

        public MovementManager(List<Block> blocks)
        {
            this.blocks = blocks;
        }

        public void Move(IMovable movable)
        {
            var direction = movable.KeyboardReader.ReadInput();
            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }

            if (direction.LengthSquared() > 0)
            {
                //acceleration
                movable.Speed += movable.Acceleration;
                movable.Speed = Limit(movable.Speed, movable.MaxSpeed);
            }
            else
            {
                //deceleration
                movable.Speed *= 0.98f;
            }

            //update position
            var distance = direction * movable.Speed;
            var futurePosition = movable.Position + distance;
            var oldPosition = movable.Position;
            movable.Position = futurePosition;
            if (CollisionManager.CheckBlockCollisions(movable, blocks))
            {
                // Revert to old position if there's a collision
                movable.Position = oldPosition;
            }
        }

        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }

    }
}