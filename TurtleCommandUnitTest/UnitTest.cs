using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleCommandWebApp.Models;

namespace TurtleCommandUnitTest
{
    [TestClass]
    public class TurtleCommandModelTest
    {
        [TestMethod]
        public void Test_Example_Scenario_1()
        {
            // Arrange
            TurtleCommand testTurtle = new TurtleCommand();
            testTurtle.Place(0, 0, Direction.North);

            // Act
            testTurtle.Move();
            testTurtle.Report();

            // Assert
            Assert.AreEqual(testTurtle.X, 0);
            Assert.AreEqual(testTurtle.Y, 1);
            Assert.AreEqual(testTurtle.Facing, Direction.North);
        }

        [TestMethod]
        public void Test_Example_Scenario_2()
        {
            // Arrange
            TurtleCommand testTurtle = new TurtleCommand();
            testTurtle.Place(0, 0, Direction.North);

            // Act
            testTurtle.Left();
            testTurtle.Report();

            // Assert
            Assert.AreEqual(testTurtle.X, 0);
            Assert.AreEqual(testTurtle.Y, 0);
            Assert.AreEqual(testTurtle.Facing, Direction.West);
        }

        [TestMethod]
        public void Test_Example_Scenario_3()
        {
            // Arrange
            TurtleCommand testTurtle = new TurtleCommand();
            testTurtle.Place(1, 2, Direction.East);

            // Act
            testTurtle.Move();
            testTurtle.Move();
            testTurtle.Left();
            testTurtle.Move();
            testTurtle.Report();

            // Assert
            Assert.AreEqual(testTurtle.X, 3);
            Assert.AreEqual(testTurtle.Y, 3);
            Assert.AreEqual(testTurtle.Facing, Direction.North);
        }

        [TestMethod]
        public void Test_Example_Scenario_4_Max_XandY()
        {
            // Arrange
            TurtleCommand testTurtle = new TurtleCommand();
            testTurtle.Place(5, 5, Direction.East);

            // Act
            testTurtle.Move();
            testTurtle.Move();
            testTurtle.Left();
            testTurtle.Move();
            testTurtle.Move();
            testTurtle.Report();

            // Assert
            Assert.AreEqual(testTurtle.X, 5);
            Assert.AreEqual(testTurtle.Y, 5);
            Assert.AreEqual(testTurtle.Facing, Direction.North);
        }

        [TestMethod]
        public void Test_Example_Scenario_5_Limit_XandY()
        {
            // Arrange
            TurtleCommand testTurtle = new TurtleCommand();
            testTurtle.Place(0, 0, Direction.East);

            // Act
            testTurtle.Right();
            testTurtle.Move();
            testTurtle.Move();
            testTurtle.Right();
            testTurtle.Move();
            testTurtle.Move();
            testTurtle.Report();

            // Assert
            Assert.AreEqual(testTurtle.X, 0);
            Assert.AreEqual(testTurtle.Y, 0);
            Assert.AreEqual(testTurtle.Facing, Direction.West);
        }

    }
}
