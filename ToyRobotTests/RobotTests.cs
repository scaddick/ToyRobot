using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToyRobots;
using ToyRobots.Controller;
using ToyRobots.Configuration;
using ToyRobots.Models;

namespace ToyRobotTests
{
    public class RobotTests
    {
        Robot _robot;
        Coordinates _coordinates;
        Table _table;
        string _direction;
        bool _returnValue;
        public RobotTests()
        {
            _table = new Table(5, 5);
            _coordinates = new Coordinates(0, 0);
            _direction = "NORTH";
            _robot = new Robot(_coordinates, _direction, _table);
        }
        [Fact]
        public void RobotHasPosition()
        {

            Assert.NotNull(_robot.GetPosition());

        }

        [Fact]
        public void RobotHasDirection()
        {
            Assert.NotNull(_robot.GetDirection());
        }

        [Fact]
        public void RobotReceivesCommand()
        {
            _returnValue = _robot.CommandToy("MOVE");
            Assert.True(_returnValue);
        }

        [Theory]
        [InlineData ("MOVE", 1, 2, "NORTH", 1, 3)]
        [InlineData ("MOVE", 1, 2, "SOUTH", 1, 1)]
        [InlineData ("MOVE", 1, 2, "EAST", 2, 2)]
        [InlineData ("MOVE", 1, 2, "WEST", 0, 2)]
        public void RobotFollowsMoveCommand(string moveCommand, int originalX, int originalY, string direction, int expectedX, int expectedY)
        {
            _coordinates = new Coordinates(originalX, originalY);
            _direction = direction;
            _robot = new Robot(_coordinates, _direction, _table);
            _returnValue = _robot.CommandToy(moveCommand);

            Coordinates result = _robot.GetPosition();
            Assert.Equal(expectedX, result.X);
            Assert.Equal(expectedY, result.Y);
        }

        [Theory]
        [InlineData (0,0,5,5,"SOUTH", 0,0)]
        [InlineData(5,5, 5, 5, "NORTH", 5, 5)]
        [InlineData(5, 5, 5, 5, "EAST", 5, 5)]
        [InlineData(0, 0, 5, 5, "WEST", 0, 0)]
        public void RobotCannotMoveBeyondBoundaryOfTable(int originalX, int originalY, int tableX, int tableY, string direction, int expectedX, int expectedY)
        {
            _table = new Table(tableX, tableY);
            _coordinates = new Coordinates(originalX, originalY);
            _direction = direction;
            _robot = new Robot(_coordinates, _direction, _table);
            _returnValue = _robot.CommandToy("MOVE");

            Coordinates result = _robot.GetPosition();
            Assert.Equal(expectedX, result.X);
            Assert.Equal(expectedY, result.Y);
            Assert.True(_returnValue);
        }

        [Theory]
        [InlineData ("LEFT", "NORTH", Compass.West)]
        [InlineData ("RIGHT", "NORTH", Compass.East)]
        [InlineData ("LEFT", "WEST", Compass.South)]
        [InlineData ("RIGHT", "WEST", Compass.North)]
        public void RobotFollowsRotateCommand(string rotateDirection, string originalDirection, Compass expectedDirection)
        {
            _robot = new Robot(_coordinates, originalDirection, _table);

            _returnValue = _robot.CommandToy(rotateDirection);

            Assert.Equal(expectedDirection, _robot.GetDirection());
        }

        [Theory]
        [InlineData ("PLACE 5,5,EAST", 5, 5, Compass.East)]
        [InlineData ("PLACE 9,0,WEST", 0, 0, Compass.North)]
        [InlineData("PLACE -1,0,SOUTH", 0, 0, Compass.North)]
        public void RobotFollowsPositionCommand(string command, int expectedX, int expectedY, Compass expectedDirection)
        {
            _returnValue = _robot.CommandToy(command);

            Assert.Equal(expectedX, _robot.GetPosition().X);
            Assert.Equal(expectedY, _robot.GetPosition().Y);
            Assert.Equal(expectedDirection, _robot.GetDirection());

        }

        [Theory]
        [InlineData ("0,0,NORTH")]
        public void RobotFollowsReportCommand(string expectedReport)
        {
            _returnValue = _robot.CommandToy("Report");
            Assert.Equal(expectedReport, _robot.Report);
        }

    }
}
