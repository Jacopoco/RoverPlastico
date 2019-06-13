using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverAPI
{
    public class Direction
    {

        public static Direction NORTH = new Direction(DirectionEnum.NORTH);
        public static Direction EAST = new Direction(DirectionEnum.EAST);
        public static Direction SOUTH = new Direction(DirectionEnum.SOUTH);
        public static Direction WEST = new Direction(DirectionEnum.WEST);
        
        private enum DirectionEnum
        {
            NORTH = 1,
            EAST,
            SOUTH,
            WEST
        }

        private DirectionEnum Value;
        
        private Direction(DirectionEnum direction)
        {
            this.Value = direction;
        }

        public Direction GetLeft()
        {
            switch (Value)
            {
                case DirectionEnum.NORTH: return WEST;
                case DirectionEnum.EAST: return NORTH;
                case DirectionEnum.SOUTH: return EAST;
                case DirectionEnum.WEST: return SOUTH;
                default: throw new InvalidOperationException("Invalid current direction");
            }
        }

        public Direction GetRight()
        {
            switch (Value)
            {
                case DirectionEnum.NORTH: return EAST;
                case DirectionEnum.EAST: return SOUTH;
                case DirectionEnum.SOUTH: return WEST;
                case DirectionEnum.WEST: return NORTH;
                default: throw new InvalidOperationException("Invalid current direction");
            }
        }

        public Direction GetOpposite()
        {
            return GetRight().GetRight();
        }

    }
}
