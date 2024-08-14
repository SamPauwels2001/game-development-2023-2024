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
        var direction = movable.KeyboardReader.ReadInput();
        if (direction != Vector2.Zero)
        {
            direction.Normalize();
        }

        //acceleration
        float maxSpeed = 5;

        if (direction.LengthSquared() > 0)
        {
            movable.Speed += movable.Acceleration;
            movable.Speed = Limit(movable.Speed, maxSpeed);
        }
        else
        {
            //deceleration
            movable.Speed *= 0.98f; 
        }

        //update position
        var distance = direction * movable.Speed;
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




/*if (movable.InputReader.IsDestinationalInput)
{
    direction -= movable.Position;
    direction.Normalize();
}*/


//var futurePosition = movable.Position + distance;
//movable.Position = futurePosition;