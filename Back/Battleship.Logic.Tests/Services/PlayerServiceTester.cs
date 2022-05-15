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

        [TestMethod]
        public void TestifMailIsValid()
        {
            string testEmail = "a@a.fr";
            PlayerService playerService = new PlayerService();
            Assert.IsTrue(playerService.IsEmailIsReal(testEmail));
        }

        [TestMethod]
        public void TestifPasswordIsCorrect()
        {
            string testPassowrd = "Test567!";
            PlayerService playerService = new PlayerService();
            Assert.IsTrue(playerService.IsPasswordCorrect(testPassowrd));
        }
        [TestMethod]
        public void TestCreateNewUser()
        {
            PlayerService playerService = new PlayerService();
            Player p = playerService.CreatePlayer();
            Assert.IsTrue(playerService.CreateNewUser(p).Name == p.Name && playerService.CreateNewUser(p).Mail == p.Mail && playerService.CreateNewUser(p).Password == p.Password); 
        }

    }
}
