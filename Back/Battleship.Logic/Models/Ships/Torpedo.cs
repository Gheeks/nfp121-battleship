using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Logic.Models
{
    public class Torpedo : Ship
    {
        public Torpedo() 
        {
            Name = "Torpedo";
            Orientation = ShipOrientation.Null;
            Size = 2;
        }
    }
}
