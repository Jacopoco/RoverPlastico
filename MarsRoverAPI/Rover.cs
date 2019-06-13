using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverAPI
{
    public class Rover
    {
        public enum RoverStatus
        {
            Operative = 1,
            StoppedFacingObstacle
        }
        
        public Direction Direction { get; private set; }
        public Position Position { get; private set; }
        public RoverStatus Status { get; private set; }
        
        public Rover(int x, int y, Direction direction)
        {
            this.Position = new Position(x, y);
            this.Direction = direction;
            this.Status = RoverStatus.Operative;
        }

        public void MoveForward()
        {
            Position nextPosition = this.Position.GetPositionFacingDirection(this.Direction);
            if (IsObstacleSenseTicklingForTargetPosition(nextPosition))
            {
                this.Status = RoverStatus.StoppedFacingObstacle;
                return;
            }

            this.Position = nextPosition;
        }

        public void MoveBackward()
        {
            Position nextPosition = this.Position.GetPositionFacingDirection(this.Direction.GetOpposite());
            if (IsObstacleSenseTicklingForTargetPosition(nextPosition))
            {
                this.Status = RoverStatus.StoppedFacingObstacle;
                return;
            }

            this.Position = nextPosition;
        }

        public void TurnLeft()
        {
            this.Direction = this.Direction.GetLeft();
        }

        public void TurnRight()
        {
            this.Direction = this.Direction.GetRight();
        }
        
        public bool IsObstacleSenseTicklingForTargetPosition(Position position)
        {
            //I would use sensors if only Nasa provided me some
            Random random = new Random(position.X + position.Y);

            if (random.Next(100) > 95)
                return true;

            return false;
        }

        public void ExecuteSequence(string sequence)
        {
            foreach(var pickedCharacter in sequence)
            {
                if (Status == RoverStatus.StoppedFacingObstacle)
                    return;

                switch (pickedCharacter)
                {
                    case 'f': MoveForward(); break;
                    case 'b': MoveBackward(); break;
                    case 'l': TurnLeft(); break;
                    case 'r': TurnRight(); break;
                }
            }
        }
        
    }
}
