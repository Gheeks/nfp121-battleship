using Battleship.Logic.Models;
using Battleship.Logic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Logic.Services
{
    public class AIService
    {
        Random random = new Random();
        public AIService()
        {

        }

        public void AutoShipPlacement(Grid g)
        {
            List<Ship> ships = new List<Ship>()
            {
                new AircraftCarrier(),
                new Cruiser(),
                new Cruiser(),
                new Destroyer(),
                new Destroyer(),
                new Torpedo(),
            };
            foreach (var ship in ships)
            {      
                int RandomOrientation = random.Next(3);
                int randomX = random.Next(7);
                int randomY = random.Next(7);   
                switch (RandomOrientation)
                {
                    case 0:
                        ship.Orientation = ShipOrientation.East;
                        break;

                    case 1:
                        ship.Orientation = ShipOrientation.South;
                        break;

                    case 2:
                        ship.Orientation = ShipOrientation.West;
                        break;
                    
                    case 3:
                        ship.Orientation = ShipOrientation.South;
                        break;
                }

                PlaceShipRecursive(g, g.cells, ship, randomX, randomY);
            }
        }

        public void PlaceShipRecursive(Grid grid, List<List<Cell>> cellList, Ship ship, int x, int y)
        {
            if (GameService._instance.GridService.PlaceShip(grid, grid.cells, ship, x, y))
            {
                Console.WriteLine("ok");
            }
            else
            {
                int newRandomX = random.Next(7);
                int newRandomY = random.Next(7);
                PlaceShipRecursive(grid, grid.cells, ship, newRandomX, newRandomY);
            }
        }

        public Grid TryHitPlayerGrid(Grid g)
        {
            return null;
            //if (gridStatus == GridStatus.NoShip_NotTouched || gridStatus == GridStatus.Ship_NotTouched)
            //{
            //    GameService._instance.GridService.SwitchState(g, x, y);
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
        }

        public Grid HitPlayerGrid(Grid g, int difficulty)
        {
            return null;
        }
    }
}
