using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Mazes.Core.Tests
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            var cell = new Cell();
        }
        
        [TestMethod]
        public void TestLinkBidirectional()
        {
            var cell1 = new Cell();
            var cell2 = new Cell();

            cell1.Link(cell2);
            Assert.IsTrue(cell1.IsLinked(cell2));
            Assert.IsTrue(cell2.IsLinked(cell1));
        }
        [TestMethod]
        public void TestLink()
        {
            var cell1 = new Cell();
            var cell2 = new Cell();

            cell1.Link(cell2, false);

            Assert.IsTrue(cell1.IsLinked(cell2));
            Assert.IsFalse(cell2.IsLinked(cell1));
        }

        [TestMethod]
        public void TestUnlinkBidirectional()
        {
            var cell1 = new Cell();
            var cell2 = new Cell();

            cell1.Link(cell2);
            cell1.Unlink(cell2);

            Assert.IsFalse(cell1.IsLinked(cell2));
            Assert.IsFalse(cell2.IsLinked(cell1));
        }

        [TestMethod]
        public void TestUnlink()
        {
            var cell1 = new Cell();
            var cell2 = new Cell();

            cell1.Link(cell2);
            cell1.Unlink(cell2, false);

            Assert.IsFalse(cell1.IsLinked(cell2));
            Assert.IsTrue(cell2.IsLinked(cell1));
        }
    }
}
