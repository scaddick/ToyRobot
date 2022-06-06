using System;
using Xunit;
using ToyRobots.Models;

namespace ToyRobotTests
{
    public class CommandTests
    {
        Commands _command;
        bool _commandResponse;
        public CommandTests()
        {
        }
        [Fact]
        public void ValidCommandIsCalled()
        {
            _command = new Commands("PLACE 0,0,NORTH");
            _commandResponse = _command.CommandIsValid;

            Assert.True(_commandResponse);
        }

        [Fact]
        public void ValidPositionCommandIsCalled()
        {
            _command = new Commands("PLACE 0,0,NORTH");
            _commandResponse = _command.CommandIsValid;

            Assert.True(_commandResponse);
        }

        [Theory]
        [InlineData("1,2,NORTH", true) ]
        [InlineData("ONE,2,NORTH", false)]
        public void ValidateCoordinatesAreNumbers(string command, bool expected)
        {
            _command = new Commands("MOVE");
            _commandResponse = _command.ValidatePlaceCommand(command);
            Assert.Equal(expected, _commandResponse);
        }


        [Theory]
        [InlineData("1,2,NORTH", true)]
        [InlineData("1,2,NORTH1", false)]
        public void ValidateDirectionIsValid(string command, bool expected)
        {
            _command = new Commands("MOVE");
            _commandResponse = _command.ValidatePlaceCommand(command);
            Assert.Equal(expected, _commandResponse);
        }
    }
}
