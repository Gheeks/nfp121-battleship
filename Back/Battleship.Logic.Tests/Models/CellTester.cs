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
    public class CellTester
    {
        [TestMethod]
        public void TestCellIsNotNullCreation()
        {
            Cell c = new Cell(0,0);
            Assert.IsNotNull(c);
        }


    }
}
