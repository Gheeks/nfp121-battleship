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
            tester.GridService.CreateNewGrid(8);
            Assert.AreEqual(8, tester.GridService.gridInstance.cells.Count);
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
                && tester.GridsPlayer.Exists(g => g.PlayerOwner == tester.Players[0])
                && tester.GridsPlayer.Exists(g => g.PlayerOwner == tester.Players[1]));
        }

        [TestMethod]
        public void TestGameBothPlayerHas6RightShips()
        {
            GameService tester = CreateGameWithTwoPlayersAnd8Grid();
            List<Ship> ships = new List<Ship>();
            tester.GridService.PlaceShipsForPlayer(tester.Players[0], ships);
            tester.GridService.PlaceShipsForPlayer(tester.Players[1], ships);
            Assert.IsTrue(tester.GridService.GetShips(tester.GridsPlayer.Find(g => g.PlayerOwner == tester.Players[0])).Count == 6
                && tester.GridService.GetShips(tester.GridsPlayer.Find(g => g.PlayerOwner == tester.Players[1])).Count == 6);
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
            tester.GridService.CreateNewGrid(8);
            return tester;
        }
    }
}
