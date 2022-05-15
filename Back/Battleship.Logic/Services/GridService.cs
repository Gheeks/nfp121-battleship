using Battleship.Logic.Models;
using Battleship.Logic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Logic.Services
{
    public class GridService
    {
        public GridService()
        {
        }

        public Grid CreateNewGrid(int dim)
        {
            Grid grid = new Grid(dim);
            grid.cells = grid.CreateGrid();
            return grid;
        }

        public bool PlaceShip(Grid grid, List<List<Cell>> cellList, Ship ship, int x, int y) 
        {
            var (succeed, errorStatus) = CheckShipRequirements(grid, ref cellList, ref ship, ref x, ref y);
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

        public (bool, List<ErrorEnum>) CheckShipRequirements(Grid grid, ref List<List<Cell>> cellList, ref Ship ship, ref int x, ref int y)
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
                        doesGridSupportShipSize = grid.CheckIfShipExistOnRange(cellList, ship, x, y);
                        break;

                    case ShipOrientation.East:
                    case ShipOrientation.West:
                        doesGridSupportShipSize = grid.CheckIfShipExistOnRange(cellList, ship, x, y);
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

        public List<Ship> GetShips(Grid g)
        {
            List<Ship> ships = new List<Ship>();
            foreach(List<Cell> cells in g.cells)
            {
                foreach (Cell cell in cells)
                {
                    if (cell.ship != null)
                    {
                        if (!ships.Contains(cell.ship))
                            ships.Add(cell.ship);
                    }
                }
            }
            return ships;
        }

        public bool PlaceShipFromFrontGrid(Grid playerGrid, Grid frontGrid)
        {
            if (frontGrid?.cells == null || playerGrid?.cells == null) return false;
            try
            {
                if (frontGrid.cells.Count != playerGrid.cells.Count) return false;
                else
                {
                    playerGrid.cells = frontGrid.cells;
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }
    }
}