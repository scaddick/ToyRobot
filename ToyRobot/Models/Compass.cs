using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobots.Models
{
    public enum Compass
    {
        North = 1,
        East = 2,
        South = 3,
        West = 4
    }

    public static class CompassConverter
    {
        public static Compass SetDirection(string direction)
        {
            direction = direction.ToUpper();
            switch (direction)
            {
                case "NORTH":
                    return Compass.North;
                    break;
                case "SOUTH":
                    return  Compass.South;
                    break;
                case "EAST":
                    return Compass.East;
                    break;
                case "WEST":
                    return Compass.West;
                    break;
                default:
                    Console.WriteLine("Compass direction is invalid");
                    return 0;
                    break;
            }
        }
    }
}
