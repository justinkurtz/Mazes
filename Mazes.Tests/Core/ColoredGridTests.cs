using Mazes.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mazes.Tests.Core
{
    [TestClass]
    public class ColoredGridTests
    {
        private ColoredGrid smallGrid;

        [TestInitialize]
        public void TestInit()
        {
            smallGrid = new ColoredGrid(2, 2);
        }

        [TestMethod]
        //[Ignore]
        public void TestToBitmap()
        {
            var bitmap = smallGrid.ToBitmap();
            bitmap.Save("test-bitmap.png");
            Assert.IsNotNull(bitmap);
        }
    }
}
