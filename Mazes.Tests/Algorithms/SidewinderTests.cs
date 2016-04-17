using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mazes.Core.Algorithms;
using Mazes.Core;

namespace Mazes.Tests.Algorithms
{
    [TestClass]
    public class SidewinderTests
    {
        [TestMethod]
        public void TestSidewinder()
        {
            var grid = new Grid(5, 5);
            Sidewinder.On(grid).ToBitmap().Save("sidewinder.png");
        }

        [TestMethod]
        public void TestBinaryTreeColoredGrid()
        {
            var coloredGrid = new ColoredGrid(25, 25);
            Sidewinder.On(coloredGrid);
            coloredGrid.Distances = coloredGrid.GetCenterCell().Distances;
            coloredGrid.ToBitmap().Save("sidewinder-colored.png");
        }
    }
}
