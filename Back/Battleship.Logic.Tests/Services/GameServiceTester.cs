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

    }
}
