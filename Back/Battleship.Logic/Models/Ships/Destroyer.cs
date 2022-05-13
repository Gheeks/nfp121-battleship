﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Logic.Models
{
    public class Destroyer : Ship
    {
        public Destroyer() 
        {
            Name = "Destroyer";
            Orientation = ShipOrientation.Null;
            Size = 3;
        }
    }
}
