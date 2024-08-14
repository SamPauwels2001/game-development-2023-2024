using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameDevProject.Input
{
    public interface IInputReader
    {
        Vector2 ReadInput();
        public bool IsDestinationInput { get; }
    }    

}