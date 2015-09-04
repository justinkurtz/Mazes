using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mazes.Core.Tests
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            var grid = new Grid(5, 5);
            Console.WriteLine(grid.ToString());
            var cell = grid[0, 1];
        }
    }
}
