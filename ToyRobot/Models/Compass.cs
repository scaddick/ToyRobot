using System;

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
                case "SOUTH":
                    return Compass.South;
                case "EAST":
                    return Compass.East;
                case "WEST":
                    return Compass.West;
                default:
                    Console.WriteLine("Compass direction is invalid");
                    return 0;
            }
        }
    }
}
