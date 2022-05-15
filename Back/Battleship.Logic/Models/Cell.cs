using Battleship.Logic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Logic.Models
{
    public class Cell
    {
        public int x;
        public int y;
        public Ship ship;
        public GridStatus touched;
        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
