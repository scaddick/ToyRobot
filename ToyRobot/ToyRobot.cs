using Microsoft.Extensions.Configuration;
using System;
using ToyRobots.Configuration;
using ToyRobots.Controller;

namespace ToyRobots
{
    public class ToyRobots
    {
        private static Table _table;

        static void Main(string[] args)
        {
            Initialise();
        }

        private static void Initialise()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appSettings.json").AddEnvironmentVariables().Build();
            Settings settings = config.GetRequiredSection("ToyRobot").Get<Settings>();

            Table(settings.Table);
            ToyController controller = new ToyController(_table);

            Console.WriteLine("Welcome to the toy Robot simulation.");
            Console.WriteLine("The table has been created this is {0} x {1} ", _table.Width, _table.Depth);
            Console.WriteLine("To initialise the robot use the command 'PLACE' followed by valid coordinates of the table and a direction");
            Console.WriteLine("Eg. PLACE 1,5,NORTH");
            Console.WriteLine("Additional commands are LEFT - to turn the robot anti-clockwise, \nRIGHT - to turn the robot clockwise");
            Console.WriteLine("MOVE - to move the robot forward one place and \nREPORT - to notify you of the position and direction of the robot");
            Console.WriteLine("To exit the simulation use the command EXIT");

            controller.Play();
        }

        public static void Table(Table table)
        {
            _table = table;
        }
    }
}
