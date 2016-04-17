using Mazes.Core.Algorithms;
using Mazes.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mazes.Tests.Algorithms
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void TestBinaryTree()
        {
            var grid = new Grid(5, 5);
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
