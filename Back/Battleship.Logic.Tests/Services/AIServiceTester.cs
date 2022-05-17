using Battleship.Logic.Models;
using Battleship.Logic.Models.Enums;
using Battleship.Logic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Logic.Tests.Services
{
    [TestClass]
    public class AIServiceTester
    {
        [TestMethod]
        public void TestAIShipPlacement()
        {
            AIService AITest = new AIService();
            GameService tester = CreateGameWithTwoPlayersAnd8Grid();

            Grid grid = tester.GetPlayerGrid(tester.Players[1]);

            AITest.AutoShipPlacement(grid);
            Assert.IsTrue(tester.GridService.GetShips(tester.GetPlayerGrid(tester.Players[1])).Count == 6);
        }

        public GameService CreateGameWithTwoPlayersAnd8Grid()
        {
            GameService tester = new GameService();
            tester.CreateNewGame();
            tester.Players.Add(tester.PlayerService.CreatePlayer());
            tester.Players.Add(tester.PlayerService.CreatePlayer());
            tester.CreateGridToPLayers(tester.Players, 8);
            return tester;
        }

        public void CreateShipForTest(GameService service, Grid g)
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
            foreach(var ship in ships)
            {
                ship.Orientation = ShipOrientation.East;
            }

            // AircraftCarrier = 5
            service.GridService.PlaceShip(g, g.cells, ships[0], 0, 0);

            // Cruiser = 4
            service.GridService.PlaceShip(g, g.cells, ships[1], 1, 0);
            service.GridService.PlaceShip(g, g.cells, ships[2], 2, 0);
            
            // Destroyer = 3
            service.GridService.PlaceShip(g, g.cells, ships[3], 3, 0);
            service.GridService.PlaceShip(g, g.cells, ships[4], 4, 0);

            // Torpedo = 2
            service.GridService.PlaceShip(g, g.cells, ships[5], 5, 0);
        }

        public GameService CreateArtificalGame()
        {
            GameService tester = CreateGameWithTwoPlayersAnd8Grid();

            // Simulate JSON grid from request
            Grid grid = new Grid(8);
            grid.cells = grid.CreateGrid();
            CreateShipForTest(tester, grid);

            // Simulate JSON grid from request
            Grid grid2 = new Grid(8);
            grid2.cells = grid2.CreateGrid();
            CreateShipForTest(tester, grid2);

            tester.PlaceShipsForPlayer(tester.Players[0], grid);
            tester.PlaceShipsForPlayer(tester.Players[1], grid2);
            return tester;
        }
    }
}
