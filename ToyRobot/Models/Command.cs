using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyRobots.Models
{
    public class Commands : ICommands
    {
        private string _primaryCommand;
        private Compass _direction; 
        private string[] _commandList;
        private Coordinates _coordinates;
        private bool _commandIsValid;

        public Commands(string command)
        {
            _commandIsValid = ValidateCommand(command);
        }

        public string[] CommandList
        {
            get => _commandList;
        }

        public bool CommandIsValid
        {
            get => _commandIsValid;
        }

        private bool ValidateCommand(string command)
        {
            // Assume that any additional data in the command is unnecessary and is ignored eg "RIGHT 2328374" ONLY "RIGHT" will be used
            _commandList = command.Split(' ');
            _primaryCommand = _commandList[0].ToUpper();
            switch (_primaryCommand)
            {
                case "PLACE":
                    if (ValidatePlaceCommand(_commandList[1])) _commandList = new string[] { _primaryCommand, _coordinates.X.ToString(), _coordinates.Y.ToString(), _direction.ToString() };
                    else return false;
                    break;
                case "MOVE":
                    _commandList = new string[] { _primaryCommand };
                    break;
                case "LEFT":
                    _commandList = new string[] {_primaryCommand};
                    break;
                case "RIGHT":
                    _commandList = new string[] { _primaryCommand };
                    break;
                case "REPORT":
                    _commandList = new string[] { _primaryCommand }; 
                    break;
                default:
                    _commandList = new string[] { "Invalid Command"};
                    return false;

            }
            return true;
        }

        public bool ValidatePlaceCommand(string placeCommand)
        {
            string[] placeParameters;
            placeParameters = placeCommand.Split(',');
            if (ValidateCoordinate(placeParameters[0]) && ValidateCoordinate(placeParameters[1]) && ValidateDirection(placeParameters[2]))
            {
                _coordinates = new Coordinates(Convert.ToInt32(placeParameters[0]), Convert.ToInt32(placeParameters[1]));
                _direction = CompassConverter.SetDirection(placeParameters[2]);
                return true;
            }
            return false;
        }

        private bool ValidateDirection(string direction)
        {
            switch (direction.ToUpper())
            {
                case "NORTH":
                    return true;
                case "SOUTH":
                    return true;
                case "EAST":
                    return true;
                case "WEST":
                    return true;
                default:
                    return false;
            }
        }

        private bool ValidateCoordinate(string coordinate)
        {
            return coordinate.All(char.IsDigit);
        }
    }
}
