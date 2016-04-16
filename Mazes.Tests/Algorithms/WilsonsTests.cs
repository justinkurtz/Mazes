using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mazes.Core;
using Mazes.Algorithms;

namespace Mazes.Tests.Algorithms
{
    [TestClass]
    public class WilsonsTests
    {
        private Grid grid;

        [TestInitialize]
        public void TestInit()
        {
            grid = new Grid(5, 5);
        }

        [TestMethod]
        public void TestWilsons()
        {
            Wilsons.On(grid).ToBitmap().Save("wilsons.png");
        }
    }
}
