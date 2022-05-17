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
        public bool IsDestroyed { get; set; } = false;
        public ShipOrientation? Orientation { get; set; }

    }
}
