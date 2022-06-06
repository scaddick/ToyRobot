using System;
using ToyRobots.Configuration;

namespace ToyRobots.Models
{
    public class Robot
    {
        private Coordinates _position;
        private Compass _direction;
        private Table _table;
        private bool _validPosition;

        public bool ValidPosition
        {
            get => _validPosition;
        }
        public string Report
        {
            get => $"{_position.X},{_position.Y},{_direction.ToString().ToUpper()}";
        }
        public Robot(Commands placeCommand, Table table)
        {
            _table = table;
            PositionToy(placeCommand.CommandList);
        }

        public Robot(Coordinates position, string direction, Table table)
        {
            _table = table;
            _position = position;
            _direction = CompassConverter.SetDirection(direction);
        }

        public Coordinates GetPosition()
        {
            return _position;
        }

        public Compass GetDirection()
        {
            return _direction;
        }

        public bool CommandToy(string commandInput)
        {
            bool commandReceived = true;
            commandInput = commandInput.ToUpper();
            Commands command = new Commands(commandInput);

            if (!command.CommandIsValid)
                return false;


            switch (command.CommandList[0])
            {
                case "MOVE":
                    Move();
                    break;
                case "LEFT":
                    RotateLeft();
                    break;
                case "RIGHT":
                    RotateRight();
                    break;
                case "PLACE":
                    PositionToy(command.CommandList);
                    break;
                case "REPORT":
                    Console.WriteLine(Report);
                    break;
                default:
                    Console.WriteLine("Invalid Command Entered");
                    break;
            }
            return commandReceived;
        }

        private void PositionToy(string[] commandList)
        {
            if (commandList.Length != 4) Console.WriteLine("Invalid Position Command");
            else
            {
                int x = Convert.ToInt32(commandList[1]);
                int y = Convert.ToInt32(commandList[2]);
                Compass newDirection = CompassConverter.SetDirection(commandList[3]);
                if (x >= 0 && x <= _table.Width && y >= 0 && y <= _table.Depth)
                {
                    _position = new Coordinates(x, y);
                    _direction = newDirection;
                    _validPosition = true;
                }
                else
                {
                    _validPosition = false;
                }
            }

        }

        private void RotateRight()
        {
            if ((int)_direction < 4)
            {
                _direction++;
            }
            else
            {
                _direction = Compass.North;
            }
        }

        private void RotateLeft()
        {
            if ((int)_direction > 1)
            {
                _direction--;
            }
            else
            {
                _direction = Compass.West;
            }
        }

        public void Move()
        {
            switch (_direction)
            {
                case Compass.North:
                    if (_position.Y < _table.Depth)
                    {
                        _position.Y++;
                    }
                    else CallOutOfBounds();

                    break;
                case Compass.South:
                    if (_position.Y > 0)
                    {
                        _position.Y--;
                    }
                    else CallOutOfBounds();
                    break;
                case Compass.East:
                    if (_position.X < _table.Width)
                    {
                        _position.X++;
                    }
                    else CallOutOfBounds();
                    break;
                case Compass.West:
                    if (_position.X > 0)
                    {
                        _position.X--;
                    }
                    else CallOutOfBounds();
                    break;
                default:
                    Console.WriteLine("Invalid direction of robot");
                    break;
            }
        }

        private void CallOutOfBounds()
        {
            Console.WriteLine("Unable to move out of Bounds: No movement made");
        }
    }
}