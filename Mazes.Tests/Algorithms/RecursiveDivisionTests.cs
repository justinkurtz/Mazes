using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mazes.Core.Algorithms;
using Mazes.Core;

namespace Mazes.Tests.Algorithms
{
    [TestClass]
    public class RecursiveDivisionTests
    {
        [TestMethod]
        public void TestRecursiveDivision()
        {
            var grid = new Grid(5, 5);
            RecursiveDivision.On(grid).ToBitmap().Save("recursivedivision.png");
        }

        [TestMethod]
        public void TestRecursiveDivisionColoredGrid()
        {
            var coloredGrid = new ColoredGrid(25, 25);
            RecursiveDivision.On(coloredGrid);
            coloredGrid.Distances = coloredGrid.GetCenterCell().Distances;
            coloredGrid.ToBitmap().Save("recursivedivision-colored.png");
        }
    }
}
