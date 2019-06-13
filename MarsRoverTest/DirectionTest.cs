using System;
using MarsRoverAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTest
{
    [TestClass]
    public class DirectionTest
    {

        [TestMethod]
        public void GetLeftFromNorth()
        {
            Assert.AreEqual(Direction.NORTH.GetLeft(), Direction.WEST);
        }

        [TestMethod]
        public void GetLeftFromEast()
        {
            Assert.AreEqual(Direction.EAST.GetLeft(), Direction.NORTH);
        }

        [TestMethod]
        public void GetLeftFromSouth()
        {
            Assert.AreEqual(Direction.SOUTH.GetLeft(), Direction.EAST);
        }

        [TestMethod]
        public void GetLeftFromWest()
        {
            Assert.AreEqual(Direction.WEST.GetLeft(), Direction.SOUTH);
        }

        [TestMethod]
        public void GetRightFromNorth()
        {
            Assert.AreEqual(Direction.NORTH.GetRight(), Direction.EAST);
        }

        [TestMethod]
        public void GetRightFromEast()
        {
            Assert.AreEqual(Direction.EAST.GetRight(), Direction.SOUTH);
        }

        [TestMethod]
        public void GetRightFromSouth()
        {
            Assert.AreEqual(Direction.SOUTH.GetRight(), Direction.WEST);
        }

        [TestMethod]
        public void GetRightFromWest()
        {
            Assert.AreEqual(Direction.WEST.GetRight(), Direction.NORTH);
        }

        [TestMethod]
        public void GetOppositeDirectionFromNorth()
        {
            Assert.AreEqual(Direction.NORTH.GetOpposite(), Direction.SOUTH);
        }

        [TestMethod]
        public void GetOppositeDirectionFromEast()
        {
            Assert.AreEqual(Direction.EAST.GetOpposite(), Direction.WEST);
        }

        [TestMethod]
        public void GetOppositeDirectionFromSouth()
        {
            Assert.AreEqual(Direction.SOUTH.GetOpposite(), Direction.NORTH);
        }

        [TestMethod]
        public void GetOppositeDirectionFromWest()
        {
            Assert.AreEqual(Direction.WEST.GetOpposite(), Direction.EAST);
        }

    }
}
