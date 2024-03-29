﻿using Battleship.Logic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship.Logic.Models
{
    public class Grid
    {
        public int Id { get; set; }
        public int Dimensions { get; set; } = 8;
        public List<List<Cell>> cells;
        public Player PlayerOwner { get; set; }

        public Grid()
        {

        }

        public Grid(int dimensions) {
            Dimensions = dimensions;
        }

        public List<List<Cell>> CreateGrid(){
            List<List<Cell>> list = new List<List<Cell>>();
            for (int i = 0; i < Dimensions; i++)
            {
                List<Cell> sublist = new List<Cell>();
                for (int j = 0; j < Dimensions; j++)
                {   
                    sublist.Add(new Cell(i, j));
                }
                list.Add(sublist);
            }
            return list;
        }

        public bool HasShip(List<List<Cell>> cellList, int x, int y)
        {
            if (x > 0 && y > 0 && x < cellList.Count-1 && y < cellList.Count - 1)
                return cellList[x][y].ship != null;
            else return false;
        }

        public bool CheckIfShipExistOnRange(List<List<Cell>> cellList, Ship ship, int x, int y)
        {
            bool hasChip = true;
            for (int i = 0; i < ship.Size ;i++)
            {
                switch (ship.Orientation) {
                    case ShipOrientation.North:
                        hasChip = HasShip(cellList,x+i,y);
                        break;
                    case ShipOrientation.South:
                        hasChip = HasShip(cellList,x-i,y);
                        break;
                    case ShipOrientation.East:
                        hasChip = HasShip(cellList,x,y+i);
                        break;
                    case ShipOrientation.West:
                        hasChip = HasShip(cellList,x+i,y-i);
                        break;
                }

                if (hasChip)
                    return true;
            }
            return false;
        }

        public GridStatus GetState(int x, int y)
        {
            try
            {
                Cell c = (from cell in cells from item in cell where item.x == x && item.y == y select item).FirstOrDefault();
                if (c != null) return c.touched;
            }
            catch (Exception ex)
            {

            }
            return default;
        }
    }
}