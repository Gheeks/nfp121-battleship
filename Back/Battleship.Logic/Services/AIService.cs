using Battleship.Logic.Models;
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

        public void AutoShipPlacement(GameService service, Grid g)
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
                int RandomOrientation = random.Next(4);
                int randomX = random.Next(8);
                int randomY = random.Next(8);   
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

                PlaceShipRecursive(service, g, g.cells, ship, randomX, randomY);
            }
        }

        public void PlaceShipRecursive(GameService service, Grid grid, List<List<Cell>> cellList, Ship ship, int x, int y)
        {
            if (service.GridService.PlaceShip(grid, grid.cells, ship, x, y)){ }
            else
            {
                int newRandomX = random.Next(8);
                int newRandomY = random.Next(8);
                PlaceShipRecursive(service, grid, grid.cells, ship, newRandomX, newRandomY);
            }
        }
    }
}
