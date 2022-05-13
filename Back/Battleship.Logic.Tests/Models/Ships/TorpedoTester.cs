using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Logic.Models.Ships
{
    [TestClass]
    public class TorpedoTester
    {
        [TestMethod]
        public void TestIfBoatSizeIsCorrect()
        {
            Torpedo ship = new Torpedo();
            Assert.AreEqual(5, ship.Size);
        }

        [TestMethod]
        public void TestIfBoatNameIsCorrect()
        {
            Torpedo ship = new Torpedo();
            Assert.AreEqual("Torpedo", ship.Name);
        }

        [TestMethod]
        public void TestIfBoatHasOrientation()
        {
            Torpedo ship = new Torpedo();
            Assert.IsNotNull(ship.Orientation);
        }

        [TestMethod]
        public void TestIfBoatHasState()
        {
            Torpedo ship = new Torpedo();
            Assert.IsNotNull(ship.isDestroyed);
        }
    }
}
