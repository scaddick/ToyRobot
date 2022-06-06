using System;
using System.Collections.Generic;
using System.Text;
using ToyRobots.Configuration;
using ToyRobots.Models;

namespace ToyRobots.Controller
{
    public class ToyController
    {
        private Table _table;
        private bool _tableIsSet;
        private bool exit;
        private Robot robot;
        private bool robotIsSet;

        public ToyController(Table table)
        {
            _table = table;
            _tableIsSet = true;
        }
        public bool TableIsSet { get => _tableIsSet; }

        internal void Play()
        {
            while (!exit)
            {
                Console.WriteLine("Please enter a command:");
                string inputCommand = Console.ReadLine();
                if(inputCommand.ToUpper() == "EXIT")
                {
                    exit = true;
                    break;
                }
                Commands command = new Commands(inputCommand);
                if(!robotIsSet && command.CommandList[0].ToUpper() != "PLACE")
                {
                    Console.WriteLine("Please start by entering a valid PLACE Command");
                }
                else if (!robotIsSet && command.CommandList[0].ToUpper() == "PLACE")
                {
                    robot = new Robot(command, _table);
                    if (!robot.ValidPosition)
                    {
                        robot = null;
                        Console.WriteLine("Invalid Place Command");
                    }
                    else
                    {
                        robotIsSet = true;
                    }
                }
                else
                {
                    robot.CommandToy(inputCommand);
                }

            }
        }
    }
}
