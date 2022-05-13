using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Logic.Models.Ships
{
    [TestClass]
    public class CruiserTester
    {
        [TestMethod]
        public void TestIfBoatSizeIsCorrect()
        {
            Cruiser ship = new Cruiser();
            Assert.AreEqual(4, ship.Size);
        }

        [TestMethod]
        public void TestIfBoatNameIsCorrect()
        {
            Cruiser ship = new Cruiser();
            Assert.AreEqual("Cruiser", ship.Name);
        }

        [TestMethod]
        public void TestIfBoatHasNoOrientation()
        {
            Cruiser ship = new Cruiser();
            Assert.IsNull(ship.Orientation);
        }

        [TestMethod]
        public void TestIfBoatHasState()
        {
            Cruiser ship = new Cruiser();
            Assert.IsNotNull(ship.IsDestroyed);
        }
    }
}
