using System;
using System.Diagnostics;
using MarsRoverAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MarsRoverAPI.Rover;

namespace MarsRoverTest
{
    [TestClass]
    public class RoverTest
    {
        [TestMethod]
        public void RoverInitialization()
        {
            Rover rover = new Rover(15, 20, Direction.NORTH);

            Assert.AreEqual(rover.Position.X, 15);
            Assert.AreEqual(rover.Position.Y, 20);
            Assert.AreEqual(rover.Direction, Direction.NORTH);
        }

        [TestMethod]
        public void MoveForwardFacingNorth()
        {
            Rover rover = new Rover(15, 20, Direction.NORTH);

            rover.MoveForward();
            Assert.AreEqual(15, rover.Position.X);
            Assert.AreEqual(21, rover.Position.Y);
        }

        [TestMethod]
        public void MoveForwardFacingEast()
        {
            Rover rover = new Rover(15, 20, Direction.EAST);

            rover.MoveForward();
            Assert.AreEqual(16, rover.Position.X);
            Assert.AreEqual(20, rover.Position.Y);
        }

        [TestMethod]
        public void MoveForwardFacingSouth()
        {
            Rover rover = new Rover(15, 20, Direction.SOUTH);

            rover.MoveForward();
            Assert.AreEqual(15, rover.Position.X);
            Assert.AreEqual(19, rover.Position.Y);
        }

        [TestMethod]
        public void MoveForwardFacingWest()
        {
            Rover rover = new Rover(15, 20, Direction.WEST);

            rover.MoveForward();
            Assert.AreEqual(14, rover.Position.X);
            Assert.AreEqual(20, rover.Position.Y);
        }


        [TestMethod]
        public void MoveBackwardFacingNorth()
        {
            Rover rover = new Rover(15, 20, Direction.NORTH);

            rover.MoveBackward();
            Assert.AreEqual(15, rover.Position.X);
            Assert.AreEqual(19, rover.Position.Y);
        }

        [TestMethod]
        public void MoveBackwardFacingEast()
        {
            Rover rover = new Rover(15, 20, Direction.EAST);

            rover.MoveBackward();
            Assert.AreEqual(14, rover.Position.X);
            Assert.AreEqual(20, rover.Position.Y);
        }

        [TestMethod]
        public void MoveBackwardFacingSouth()
        {
            Rover rover = new Rover(15, 20, Direction.SOUTH);

            rover.MoveBackward();
            Assert.AreEqual(15, rover.Position.X);
            Assert.AreEqual(21, rover.Position.Y);
        }

        [TestMethod]
        public void MoveBackwardFacingWest()
        {
            Rover rover = new Rover(15, 20, Direction.WEST);

            rover.MoveBackward();
            Assert.AreEqual(16, rover.Position.X);
            Assert.AreEqual(20, rover.Position.Y);
        }

        [TestMethod]
        public void TurnLeft()
        {
            Rover rover = new Rover(15, 20, Direction.NORTH);

            rover.TurnLeft();
            Assert.AreEqual(Direction.WEST, rover.Direction);

            rover.TurnLeft();
            Assert.AreEqual(Direction.SOUTH, rover.Direction);

            rover.TurnLeft();
            Assert.AreEqual(Direction.EAST, rover.Direction);

            rover.TurnLeft();
            Assert.AreEqual(Direction.NORTH, rover.Direction);
        }

        [TestMethod]
        public void TurnRight()
        {
            Rover rover = new Rover(15, 20, Direction.NORTH);

            rover.TurnRight();
            Assert.AreEqual(Direction.EAST, rover.Direction);

            rover.TurnRight();
            Assert.AreEqual(Direction.SOUTH, rover.Direction);

            rover.TurnRight();
            Assert.AreEqual(Direction.WEST, rover.Direction);

            rover.TurnRight();
            Assert.AreEqual(Direction.NORTH, rover.Direction);
        }

        [TestMethod]
        public void StopAtObstacleMovingForward()
        {
            Rover rover = new Rover(15, 17, Direction.NORTH);

            rover.MoveForward();

            Assert.AreEqual(RoverStatus.StoppedFacingObstacle, rover.Status);
            Assert.AreEqual(15, rover.Position.X);
            Assert.AreEqual(17, rover.Position.Y);
        }

        [TestMethod]
        public void StopAtObstacleMovingBackward()
        {
            Rover rover = new Rover(15, 19, Direction.NORTH);

            rover.MoveBackward();

            Assert.AreEqual(RoverStatus.StoppedFacingObstacle, rover.Status);
            Assert.AreEqual(15, rover.Position.X);
            Assert.AreEqual(19, rover.Position.Y);
        }

        [TestMethod]
        public void ExecuteSequence()
        {
            Rover rover = new Rover(15, 20, Direction.NORTH);

            rover.ExecuteSequence("ffrfffffflbbffbbffbbbbrrrrrlrff");
            /*
                15 20 N
                ffr
                15 22 E
                ffffffl
                21 22 N
                (bbff)(bbff)bbbb (rrrr)(rl)r 
                21 18 E
                ff
                23 18
            */
            Assert.AreEqual(RoverStatus.Operative, rover.Status);
            Assert.AreEqual(23, rover.Position.X);
            Assert.AreEqual(18, rover.Position.Y);
            Assert.AreEqual(Direction.EAST, rover.Direction);
        }

        [TestMethod]
        public void ExecuteSequenceCollidingObstacle()
        {
            Rover rover = new Rover(15, 20, Direction.NORTH);

            rover.ExecuteSequence("fflfffrbbbrrrffff");
            /*
                15 20 N
                ffl
                15 22 W
                fffr
                12 22 N
                bbbr
                12 19 N (obstacle at 12 21, stops at 12 22)  
            */
            Assert.AreEqual(RoverStatus.StoppedFacingObstacle, rover.Status);
            Assert.AreEqual(12, rover.Position.X);
            Assert.AreEqual(22, rover.Position.Y);
            Assert.AreEqual(Direction.NORTH, rover.Direction);
        }

        //[TestMethod]
        //[Ignore]
        //public void FindAllObstacles()
        //{
        //    Rover rover = new Rover(0, 0, Direction.NORTH);
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        for(int j = 0; j < 1000; j++)
        //        {
        //            if (rover.IsObstacleSenseTicklingForTargetPosition(new Position(i,j)))
        //            {
        //                Debug.WriteLine($"{i}X {j}Y");
        //            }
        //        }
        //    }
        //}

    }
}
