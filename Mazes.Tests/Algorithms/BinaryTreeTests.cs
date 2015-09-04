using System;
using Mazes.Algorithms;
using Mazes.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mazes.Tests.Algorithms
{
    [TestClass]
    public class BinaryTreeTests
    {
        private Grid grid;

        [TestInitialize]
        public void TestInit()
        {
            grid = new Grid(5, 5);
        }

        [TestMethod]
        public void TestRun()
        {
            BinaryTree.On(grid).ToBitmap().Save("binarytree-maze.png");
        }
    }
}
