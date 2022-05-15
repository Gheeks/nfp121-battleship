
using Battleship.Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Logic.Tests.Models
{
    [TestClass]
    public class PlayerTester
    {
        [TestMethod]
        public void TestPlayerIsNotNullCreation()
        {
            Player p = new Player("1", "a@a.fr", "a");
            Assert.IsNotNull(p);
        }
    }
}
