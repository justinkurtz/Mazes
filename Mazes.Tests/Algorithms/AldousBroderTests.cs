using Mazes.Core;
using Mazes.Core.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Mazes.Tests.Algorithms
{
    [TestClass]
    public class AldousBroderTests
    {
        private Grid grid;

        [TestInitialize]
        public void TestInit()
        {
            grid = new Grid(5, 5);
        }

        [TestMethod]
        public void TestAldousBroder()
        {
            AldousBroder.On(grid).ToBitmap().Save("aldousbroder.png");
        }
    }
}
