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
            Assert.AreEqual(2, ship.Size);
        }

        [TestMethod]
        public void TestIfBoatNameIsCorrect()
        {
            Torpedo ship = new Torpedo();
            Assert.AreEqual("Torpedo", ship.Name);
        }

        [TestMethod]
        public void TestIfBoatHasNoOrientation()
        {
            Torpedo ship = new Torpedo();
            Assert.IsNull(ship.Orientation);
        }

        [TestMethod]
        public void TestIfBoatHasState()
        {
            Torpedo ship = new Torpedo();
            Assert.IsNotNull(ship.IsDestroyed);
        }
    }
}
