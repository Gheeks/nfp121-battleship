﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Logic.Models
{
    public class Cruiser : Ship
    {
        public Cruiser()
        {
            Name = "Cruiser";
            Orientation = ShipOrientation.Null;
            Size = 4;
        }
    }
}
