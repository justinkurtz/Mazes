﻿using Mazes.Core;
using Mazes.Core.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mazes.Tests.Algorithms
{
    [TestClass]
    public class AldousBroderTests
    {
        [TestMethod]
        public void TestAldousBroder()
        {
            var grid = new Grid(5, 5);
            AldousBroder.On(grid).ToBitmap().Save("aldousbroder.png");
        }

        [TestMethod]
        public void TestAldousBroderColored()
        {
            var coloredGrid = new ColoredGrid(25, 25);
            AldousBroder.On(coloredGrid);
            coloredGrid.Distances = coloredGrid.GetCenterCell().Distances;
            coloredGrid.ToBitmap().Save("aldousbroder-colored.png");
        }
    }
}
