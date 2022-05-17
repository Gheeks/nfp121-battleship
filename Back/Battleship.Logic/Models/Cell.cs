using Battleship.Logic.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Logic.Models
{
    public class Cell
    {
        public int Id { get; set; }
        public int GridId { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public Ship? ship { get; set; }
        public GridStatus touched { get; set; }
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
