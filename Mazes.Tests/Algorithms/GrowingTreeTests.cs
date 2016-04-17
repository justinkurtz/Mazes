using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mazes.Core;
using Mazes.Core.Algorithms;

namespace Mazes.Tests.Algorithms
{
    [TestClass]
    public class GrowingTreeTests
    {
        [TestMethod]
        public void TestGrowingTree()
        {
            var grid = new Grid(5, 5);
            GrowingTree.On(grid).ToBitmap().Save("growingtree.png");
        }

        [TestMethod]
        public void TestGrowingTreeColored()
        {
            var coloredGrid = new ColoredGrid(25, 25);
            GrowingTree.On(coloredGrid);
            coloredGrid.Distances = coloredGrid.GetCenterCell().Distances;
            coloredGrid.ToBitmap().Save("growingtree-colored.png");
        }
    }
}
