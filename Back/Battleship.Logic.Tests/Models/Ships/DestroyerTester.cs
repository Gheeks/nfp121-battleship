using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Logic.Models.Ships
{
    [TestClass]
    public class DestroyerTester
    {
        [TestMethod]
        public void TestIfBoatSizeIsCorrect()
        {
            Destroyer ship = new Destroyer();
            Assert.AreEqual(3, ship.Size);
        }

        [TestMethod]
        public void TestIfBoatNameIsCorrect()
        {
            Destroyer ship = new Destroyer();
            Assert.AreEqual("Destroyer", ship.Name);
        }

        [TestMethod]
        public void TestIfBoatHasNoOrientation()
        {
            Destroyer ship = new Destroyer();
            Assert.AreEqual(ShipOrientation.Null, ship.Orientation);
        }

        [TestMethod]
        public void TestIfBoatHasState()
        {
            Destroyer ship = new Destroyer();
            Assert.IsNotNull(ship.IsDestroyed);
        }
    }
}
