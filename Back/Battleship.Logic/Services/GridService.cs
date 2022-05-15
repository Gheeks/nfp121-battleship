using Battleship.Logic.Models;
using Battleship.Logic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Logic.Services
{
    public class GridService
    {
        public Grid gridInstance { get; set; }

        public GridService()
        {
        }

        public GridService(Grid g) 
        {
            gridInstance = g;
        }
        
        public Grid CreateNewGrid(int dim)
        {
            this.gridInstance = new Grid(dim);
            this.gridInstance.cells = this.gridInstance.CreateGrid();
            return this.gridInstance;
        }

        public bool PlaceShip(List<List<Cell>> cellList, Ship ship, int x, int y) 
        {
            var (succeed, errorStatus) = CheckShipRequirements(ref cellList, ref ship, ref x, ref y);
            if (succeed)
            {
                try
                {
                    for (int i = 0; i < ship.Size; i++) 
                    {
                        switch (ship.Orientation)
                        {
                            case ShipOrientation.North:
                                cellList[x + i][y].ship = ship;
                                break;
                            case ShipOrientation.South:
                                cellList[x - i][y].ship = ship;
                                break;
                            case ShipOrientation.East:
                                cellList[x][y + i].ship = ship;
                                break;
                            case ShipOrientation.West:
                                cellList[x][y - i].ship = ship;
                                break;
                            // Todo: HORIZONTAL PLACEMENT
                        }
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public (bool, List<ErrorEnum>) CheckShipRequirements(ref List<List<Cell>> cellList, ref Ship ship, ref int x, ref int y)
        {
            Cell initialCell = cellList[x][y];
            List<ErrorEnum> errors = new List<ErrorEnum>();
            if (ship.Size > Grid.Dimensions || 
                (ship.Orientation == ShipOrientation.West && x - ship.Size < 0) ||
                (ship.Orientation == ShipOrientation.East && x + ship.Size > Grid.Dimensions) ||
                (ship.Orientation == ShipOrientation.North && y + ship.Size < 0) ||
                (ship.Orientation == ShipOrientation.South && y + ship.Size > Grid.Dimensions))
            {
                errors.Add(ErrorEnum.SHIP_EXCEED_LIMITS);
                return (false, errors);
            }
            else
            {
                bool doesGridSupportShipSize = true;
                switch (ship.Orientation)
                {
                    case ShipOrientation.North:
                    case ShipOrientation.South:
                        doesGridSupportShipSize = gridInstance.CheckIfShipExistOnRange(cellList, ship, x, 0);
                        break;

                    case ShipOrientation.East:
                    case ShipOrientation.West:
                        doesGridSupportShipSize = gridInstance.CheckIfShipExistOnRange(cellList, ship, 0, y);
                        break;
                }

                if (initialCell.ship == null && !doesGridSupportShipSize)
                {
                    initialCell.ship = ship;
                    return (true, errors);
                }
                else
                {
                    errors.Add(ErrorEnum.SHIP_PLACED_ON_OTHER);
                    return (false, errors);
                }
            }
        }

        public bool PlaceShipsForPlayer(Player p, List<Ship> ships)
        {
            return false;
        }

        public List<Ship> GetShips(Grid g)
        {
            return null;
        }
    }
}