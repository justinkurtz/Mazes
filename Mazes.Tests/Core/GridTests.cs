using Mazes.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Mazes.Tests.Core
{
    [TestClass]
    public class GridTests
    {
        private Grid smallGrid;

        [TestInitialize]
        public void TestInit()
        {
            smallGrid = new Grid(2, 2);
        }

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(2, smallGrid.Rows);
            Assert.AreEqual(2, smallGrid.Columns);
        }

        [TestMethod]
        public void TestCount()
        {
            Assert.AreEqual(4, smallGrid.Count());
        }

        [TestMethod]
        public void TestEnumerate()
        {
            foreach (Cell cell in smallGrid)
            {
                Assert.IsNotNull(cell);
            }
        }

        [TestMethod]
        public void TestEachRow()
        {
            int count = 0;
            foreach (IEnumerable<Cell> row in smallGrid.EachRow())
            {
                Assert.AreEqual(2, row.Count());
                count++;
            }

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void TestRandomCell()
        {
            var cell = smallGrid.GetRandomCell();
            Assert.IsNotNull(cell);
        }

        [TestMethod]
        public void TestToBitmap()
        {
            var bitmap = smallGrid.ToBitmap();
            bitmap.Save("2x2.png");
            Assert.IsNotNull(bitmap);
        }

        [TestMethod]
        public void TestToBitmapWithLinks()
        {
            var cell = smallGrid[0, 0];
            cell.Link(cell.South).Link(cell.East).East.Link(cell.East.South);

            var bitmap = smallGrid.ToBitmap();
            bitmap.Save("2x2-linked.png");
            Assert.IsNotNull(bitmap);
        }
    }
}
