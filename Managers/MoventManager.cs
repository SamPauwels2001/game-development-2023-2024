using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameDevProject.Input;
using System.Collections.Generic;
using GameDevProject.Interfaces;

class MovementManager
{
    public void Move(IMovable movable)
    {
        movable.Speed += movable.Acceleration;
        float maxSpeed = 10;
        movable.Speed = Limit(movable.Speed, maxSpeed);

        var direction = movable.KeyboardReader.ReadInput();
        /*if (movable.InputReader.IsDestinationalInput)
        {
            direction -= movable.Position;
            direction.Normalize();
        }*/

        var distance = direction * movable.Speed;

        //update position
        movable.Position += distance;
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

