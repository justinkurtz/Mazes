using Mazes.Core;
using Mazes.Core.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mazes.Tests.Algorithms
{
    [TestClass]
    public class HuntAndKillTests
    {
        [TestMethod]
        public void TestHuntAndKill()
        {
            var grid = new Grid(5, 5);
            HuntAndKill.On(grid).ToBitmap().Save("huntandkill.png");
        }

        [TestMethod]
        public void TestHuntAndKillColored()
        {
            var coloredGrid = new ColoredGrid(25, 25);
            HuntAndKill.On(coloredGrid);
            coloredGrid.Distances = coloredGrid.GetCenterCell().Distances;
            coloredGrid.ToBitmap().Save("huntandkill-colored.png");
        }
    }
}
