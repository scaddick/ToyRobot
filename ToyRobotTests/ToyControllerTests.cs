using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToyRobots;
using ToyRobots.Controller;
using ToyRobots.Configuration;

namespace ToyRobotTests
{
    public class ToyControllerTests
    {
        [Fact]
        public void TableDimentionsAreValid()
        {
            bool tableDimentionsAreValid = false;
            Table table = new Table(5, 5);
            ToyController controller = new ToyController(table);
            if (controller.TableIsSet)
            {
                if (table.Width <= 0 || table.Depth <= 0)
                {
                    tableDimentionsAreValid = false;
                }
                else
                {
                    tableDimentionsAreValid = true;
                }
            }

            Assert.True(tableDimentionsAreValid);
        }
    }
}
