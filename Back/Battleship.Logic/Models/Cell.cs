using Battleship.Logic.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Logic.Models
{
    [Keyless]
    public class Cell
    {
        public int x;
        public int y;
        public Ship ship;
        public GridStatus touched;
        public Cell(int x, int y)
        {
            touched = GridStatus.NoShip_NotTouched;
            this.x = x;
            this.y = y;
        }

        private Cell()
        {

        }
    }
}
