using System;
using MarsRoverAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTest
{
    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        public void PositionInitialization()
        {
            Position position = new Position(15, 20);
            Assert.AreEqual(15, position.X);
            Assert.AreEqual(20, position.Y);
        }

        [TestMethod]
        public void GetNextPositionFacingNorth()
        {
            Position position = new Position(15, 20);
            Position newPosition = position.GetPositionFacingDirection(Direction.NORTH);
            Assert.AreEqual(15, newPosition.X);
            Assert.AreEqual(21, newPosition.Y);
        }

        [TestMethod]
        public void GetNextPositionFacingEast()
        {
            Position position = new Position(15, 20);
            Position newPosition = position.GetPositionFacingDirection(Direction.EAST);
            Assert.AreEqual(16, newPosition.X);
            Assert.AreEqual(20, newPosition.Y);
        }

        [TestMethod]
        public void GetNextPositionFacingSouth()
        {
            Position position = new Position(15, 20);
            Position newPosition = position.GetPositionFacingDirection(Direction.SOUTH);
            Assert.AreEqual(15, newPosition.X);
            Assert.AreEqual(19, newPosition.Y);
        }

        [TestMethod]
        public void GetNextPositionFacingWest()
        {
            Position position = new Position(15, 20);
            Position newPosition = position.GetPositionFacingDirection(Direction.WEST);
            Assert.AreEqual(14, newPosition.X);
            Assert.AreEqual(20, newPosition.Y);
        }

        [TestMethod]
        public void TestNorthWorldBoundaryCrossing()
        {
            Position position = new Position(500, 999);

            Position newPosition = position.GetPositionFacingDirection(Direction.NORTH);
            Assert.AreEqual(500, newPosition.X);
            Assert.AreEqual(0, newPosition.Y);
        }

        [TestMethod]
        public void TestEastWorldBoundaryCrossing()
        {
            Position position = new Position(999, 500);

            Position newPosition = position.GetPositionFacingDirection(Direction.EAST);
            Assert.AreEqual(0, newPosition.X);
            Assert.AreEqual(500, newPosition.Y);
        }

        [TestMethod]
        public void TestSouthWorldBoundaryCrossing()
        {
            Position position = new Position(500, 0);

            Position newPosition = position.GetPositionFacingDirection(Direction.SOUTH);
            Assert.AreEqual(500, newPosition.X);
            Assert.AreEqual(999, newPosition.Y);
        }

        [TestMethod]
        public void TestWestWorldBoundaryCrossing()
        {
            Position position = new Position(0, 500);

            Position newPosition = position.GetPositionFacingDirection(Direction.WEST);
            Assert.AreEqual(999, newPosition.X);
            Assert.AreEqual(500, newPosition.Y);
        }

    }
}
