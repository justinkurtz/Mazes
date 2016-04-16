using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mazes.Core;

namespace Mazes.Tests.Core
{
    [TestClass]
    public class DistancesTests
    {
        private Distances distances;
        private Grid grid;

        [TestInitialize]
        public void TestInit()
        {
            grid = new Grid(2, 2);
            distances = new Distances(grid[0, 0]);
        }

        [TestMethod]
        public void TestConstructor()
        {
            Assert.IsNotNull(distances);
        }

        [TestMethod]
        public void TestGetMaxDistance1()
        {
            var cell = grid[0, 0];
            cell.Link(cell.South);

            Assert.AreEqual(1, grid[0, 0].Distances.Max);
        }

        [TestMethod]
        public void TestGetMaxDistance2()
        {
            var cell = grid[0, 0];
            cell.Link(cell.East).East.Link(cell.East.South);

            Assert.AreEqual(2, grid[0, 0].Distances.Max);
        }
    }
}
