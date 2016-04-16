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
        public void TestBinaryTree()
        {
            BinaryTree.On(grid).ToBitmap().Save("binarytree.png");
        }

        [TestMethod]
        public void TestBinaryTreeColoredGrid()
        {
            var coloredGrid = new ColoredGrid(25, 25);
            BinaryTree.On(coloredGrid);
            coloredGrid.Distances = coloredGrid.GetCenterCell().Distances;
            coloredGrid.ToBitmap().Save("binarytree-colored.png");
        }
    }
}
