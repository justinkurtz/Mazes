﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void TestWilsonsColoredGrid()
        {
            var coloredGrid = new ColoredGrid(25, 25);
            Wilsons.On(coloredGrid);
            coloredGrid.Distances = coloredGrid.GetCenterCell().Distances;
            coloredGrid.ToBitmap().Save("wilsons-colored.png");
        }
    }
}
