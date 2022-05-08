using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Logic.Models
{
    public class Ship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public bool isDestroyed { get; set; }
        public ShipOrientation Orientation { get; set; }

        public Ship(string name, int size, ShipOrientation shipOrientation) 
        {
            Name = name; 
            Size = size;
            Orientation = shipOrientation;
        }
    }
}
