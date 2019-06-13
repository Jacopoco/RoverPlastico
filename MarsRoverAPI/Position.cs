using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverAPI
{
    public class Position
    {
        const int MARSWIDTH = 1000;
        const int MARSHEIGHT = 1000;

        public int X { get; private set; }
        public int Y { get; private set; }
        
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Position GetPositionFacingDirection(Direction direction)
        {
            Position newPosition = new Position(this.X, this.Y);

            if (direction == Direction.NORTH)
                newPosition.Y++;
            else if (direction == Direction.EAST)
                newPosition.X++;
            else if (direction == Direction.SOUTH)
                newPosition.Y--;
            else if (direction == Direction.WEST)
                newPosition.X--;

            if (newPosition.X < 0)
                newPosition.X = MARSWIDTH - 1;

            if (newPosition.X >= MARSWIDTH)
                newPosition.X = 0;

            if (newPosition.Y < 0)
                newPosition.Y = MARSHEIGHT - 1;

            if (newPosition.Y >= MARSHEIGHT)
                newPosition.Y = 0;
            
            return newPosition;
        }
        
    }
}
