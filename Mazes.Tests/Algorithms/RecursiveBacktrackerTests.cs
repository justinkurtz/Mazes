using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mazes.Core.Algorithms;
using Mazes.Core;

namespace Mazes.Tests.Algorithms
{
    [TestClass]
    public class RecursiveBacktrackerTests
    {
        [TestMethod]
        public void TestRecursiveBacktracker()
        {
            var grid = new Grid(5, 5);
            RecursiveBacktracker.On(grid).ToBitmap().Save("recursivebacktracker.png");
        }

        [TestMethod]
        public void TestRecursiveBacktrackerColored()
        {
            var coloredGrid = new ColoredGrid(25, 25);
            RecursiveBacktracker.On(coloredGrid);
            coloredGrid.Distances = coloredGrid.GetCenterCell().Distances;
            coloredGrid.ToBitmap().Save("recursivebacktracker-colored.png");
        }
    }
}
