using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mazes.Algorithms;

namespace Mazes.Core.Tests
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            var grid = new Grid(5, 5);
            Console.WriteLine(BinaryTree.On(grid).ToString());
        }
    }
}
