using Battleship.Logic.Models;
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
    public class GameServiceTester
    {
        [TestMethod]
        public void TestGameCreationGrid8Service()
        {
            GameService tester = new GameService();
            tester.CreateNewGame();
            Grid g = tester.GridService.CreateNewGrid(8);
            Assert.AreEqual(8, g.cells.Count);
        }

        [TestMethod]
        public void TestGameCreationTwoPlayers()
        {
            GameService tester = new GameService();
            tester.CreateNewGame();
            tester.Players.Add(tester.PlayerService.CreatePlayer());
            tester.Players.Add(tester.PlayerService.CreatePlayer());
            Assert.AreEqual(2, tester.Players.Count);
        }

        [TestMethod]
        public void TestBothPlayersHaveGrid()
        {
            GameService tester = CreateGameWithTwoPlayersAnd8Grid();
            Assert.IsTrue(tester.GridsPlayer.Count == 2
                && tester.GridsPlayer.ContainsKey(tester.Players[0])
                && tester.GridsPlayer.ContainsKey(tester.Players[1]));
        }

        [TestMethod]
        public void TestGameBothPlayerHas6RightShips()
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

            Assert.IsTrue(tester.GridService.GetShips(tester.GridsPlayer.FirstOrDefault(g => g.Key == tester.Players[0]).Value).Count == 6
                && tester.GridService.GetShips(tester.GridsPlayer.FirstOrDefault(g => g.Key == tester.Players[1]).Value).Count == 6);
        }

        [TestMethod]
        public void TestPlayerCanHitBoat()
        {
            GameService tester = CreateGameWithTwoPlayersAnd8Grid();
            //tester.GridService.PlaceShip(tester.GridService.gridInstance.cells, new Ship());
        }


        [TestMethod]
        public void TestPlayerCanHitBoatTillHeFall()
        {
            GameService tester = CreateGameWithTwoPlayersAnd8Grid();
            //tester.GridService.PlaceShip(tester.GridService.gridInstance.cells, new Ship());
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
    }
}
