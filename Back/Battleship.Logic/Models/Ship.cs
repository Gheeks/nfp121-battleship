using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Logic.Models
{
    public class Ship
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public bool isDestroyed { get; set; } = false;
        public ShipOrientation Orientation { get; set; }

        public Ship() {}

        public Ship(string name, int size, ShipOrientation shipOrientation) 
        {
            Name = name; 
            Size = size;
            Orientation = shipOrientation;
        }
    }
}
