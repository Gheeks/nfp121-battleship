using Battleship.Logic.Models;
using Battleship.Logic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Logic.Tests.Models
{
    [TestClass]
    public class GridTester
    {
        [TestMethod]
        public void TestGridWith0AndEmptyList()
        {
            Grid g = new Grid(0);
            Assert.AreEqual(0, g.CreateGrid().Count);
        }

        [TestMethod]
        public void TestGridWith2AndTwoDimensionList()
        {
            TestListDimensions(2);
        }

        [TestMethod]
        public void TestGridWith8AndEightDimensionList()
        {
            TestListDimensions(8);
        }

        public void TestListDimensions(int dim)
        {
            Grid g = new Grid(dim);
            List<List<Cell>> cells = g.CreateGrid();
            Assert.AreEqual(dim, cells.Count);
            foreach (List<Cell> row in cells)
            {
                Assert.AreEqual(dim, row.Count);
            }
        }


        [TestMethod]
        public void TestGridWithPlacement()
        {
            var (g,cells, gridService) = CreateTestEnvironnement(8);
            Ship ship = new Ship("GroBato", 4, ShipOrientation.East);
            gridService.PlaceShip(cells, ship, 1, 1);
            for(int i = 1; i < 4; i++)
            {
                Assert.AreEqual(true, g.HasShip(cells, 1, i));
            }
        }

        [TestMethod]
        public void TestGridWithPlacementOutOfBound()
        {
            var (g, cells, gridService) = CreateTestEnvironnement(2);
            Ship ship = new Ship("TroGroBato", 4, ShipOrientation.East);
            Assert.AreEqual(false, gridService.PlaceShip(cells, ship, 1, 1));
        }

        [TestMethod]
        public void TestGridWithPlacementWithShipIn()
        {
            var (g, cells, gridService) = CreateTestEnvironnement(8);
            Ship ship = new Ship("GroBato", 4, ShipOrientation.East);
            gridService.PlaceShip(cells, ship, 1, 1);
            Assert.AreEqual(false, gridService.PlaceShip(cells, ship, 1, 1));
        }

        [TestMethod]
        public void TestGridWithPlacementOfMultipleShip()
        {
            var (g, cells, gridService) = CreateTestEnvironnement(8);
            Ship ship = new Ship("GroBato", 5, ShipOrientation.East);
            Ship ship1 = new Ship("GroBato", 4, ShipOrientation.North);
            Ship ship2 = new Ship("GroBato", 2, ShipOrientation.South);
            Assert.AreEqual(true, gridService.PlaceShip(cells, ship, 1, 1));
            Assert.AreEqual(true, gridService.PlaceShip(cells, ship1, 2, 3));
            Assert.AreEqual(true, gridService.PlaceShip(cells, ship2, 5, 2));
        }

        public (Grid, List<List<Cell>>, GridService) CreateTestEnvironnement(int dim)
        {
            Grid g = new Grid(dim);
            List<List<Cell>> cells = g.CreateGrid();
            GridService gridService = new GridService(g);
            return (g,cells, gridService);
        }
    }
}
