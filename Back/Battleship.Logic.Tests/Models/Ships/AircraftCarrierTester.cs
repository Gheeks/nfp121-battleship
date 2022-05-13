using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Logic.Models.Ships
{
    [TestClass]
    public class AircraftCarrierTester
    {
        [TestMethod]
        public void TestIfBoatSizeIsCorrect()
        {
            AircraftCarrier ship = new AircraftCarrier();
            Assert.AreEqual(5, ship.Size);
        }

        [TestMethod]
        public void TestIfBoatNameIsCorrect()
        {
            AircraftCarrier ship = new AircraftCarrier();
            Assert.AreEqual("Aircraft Carrier", ship.Name);
        }

        [TestMethod]
        public void TestIfBoatHasOrientation()
        {
            AircraftCarrier ship = new AircraftCarrier();
            Assert.IsNotNull(ship.Orientation);
        }

        [TestMethod]
        public void TestIfBoatHasState()
        {
            AircraftCarrier ship = new AircraftCarrier();
            Assert.IsNotNull(ship.isDestroyed);
        }
    }
}
