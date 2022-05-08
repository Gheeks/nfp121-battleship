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
    public class ShipTester
    {
        [TestMethod]
        public void TestShipIsNotNull()
        {
            Ship g = new Ship("test",1, ShipOrientation.North);
            Assert.IsNotNull(g);
        }
    }
}
