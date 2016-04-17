using Mazes.Core;
using Mazes.Core.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mazes.Tests.Core
{
    [TestClass]
    public class ColoredGridTests
    {
        private ColoredGrid grid;

        [TestInitialize]
        public void TestInit()
        {
            grid = new ColoredGrid(5, 5);
        }

        [TestMethod]
        public void TestBinaryTreeColoredGrid()
        {
            BinaryTree.On(grid);
            grid.Distances = grid.GetCenterCell().Distances;
            var bitmap = grid.ToBitmap();
            Assert.IsNotNull(bitmap);
        }
    }
}
