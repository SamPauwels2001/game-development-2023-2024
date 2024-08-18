using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDevProject.Interfaces;
using GameDevProject.Input;

public interface IMovable
{
    public Vector2 Position { get; set; }
    public Vector2 Speed { get; set; }
    public float MaxSpeed { get; set; }
    public Vector2 Acceleration { get; set; }
    public IInputReader KeyboardReader { get; set; }
    int Width { get;}
    int Height { get;}
}
