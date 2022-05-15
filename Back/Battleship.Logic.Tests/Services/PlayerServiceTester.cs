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
    public class PlayerServiceTester
    {
        [TestMethod]
        public void TestPlayerIsRandom()
        {
            PlayerService playerService = new PlayerService();
            List<Player> list = new List<Player>();
            list.Add(playerService.CreatePlayer());
            list.Add(playerService.CreatePlayer());
            Player firstRandom = null;
            Player nextRandoms = null;
            // Coin flip model => proba to get the same is 2!i
            for (int i = 0; i < 100; i++)
            {
                if (i == 0)
                    firstRandom = playerService.RandomFirstPlayer(list);
                else
                {
                    nextRandoms = playerService.RandomFirstPlayer(list);
                    if (nextRandoms != firstRandom)
                        Assert.IsTrue(nextRandoms != firstRandom);
                }
            }
        }

    }
}
