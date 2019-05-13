using System;
using System.Collections.Generic;
using System.Text;
using Game;
using NUnit.Framework;


namespace Tests
{
    class PlayerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanMoveInDirection_OutOfBounds()
        {
            // Arrange
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "Owg" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool canMove = currPlayer.CanMoveInDirection(theBoard,Direction.North);

            // Assert
            Assert.IsTrue(canMove, "Error");
        }

        [Test]
        public void CanMoveInDirection_OnWall()
        {
            // Arrange
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "Owg" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool canMove = currPlayer.CanMoveInDirection(theBoard, Direction.West);

            // Assert
            Assert.IsTrue(canMove, "Error");
        }

        [Test]
        public void CanMoveInDirection_OnItem()
        {
            // Arrange
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "Owg" +
                "iwO" +
                "OOO",
                3);

            // Act
            bool canMove = currPlayer.CanMoveInDirection(theBoard, Direction.South);

            // Assert
            Assert.IsFalse(canMove, "Error");
        }

        [Test]
        public void CanMoveInDirection_OnGoal()
        {
            // Arrange
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "OgO" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool canMove = currPlayer.CanMoveInDirection(theBoard, Direction.West);

            // Assert
            Assert.IsTrue(canMove, "Error");
        }

        [Test]
        public void Move_OutOfBounds()
        {
            // Arrange
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool canMove = currPlayer.Move(theBoard, Direction.North);

            // Assert
            Assert.IsFalse(canMove, "Error");
        }

        [Test]
        public void Move_OnWall()
        {
            // Arrange
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "Owg" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool canMove = currPlayer.Move(theBoard, Direction.West);

            // Assert
            Assert.IsFalse(canMove, "Error");
        }

        [Test]
        public void Move_OnGoal()
        {
            // Arrange
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "OgO" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool canMove = currPlayer.Move(theBoard, Direction.West);

            // Assert
            Assert.IsFalse(canMove, "Error");
        }

        [Test]
        public void Move_OnItem()
        {
            // Arrange
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "Oig" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool canMove = currPlayer.Move(theBoard, Direction.West);

            // Assert
            Assert.IsFalse(canMove, "Error");
        }
    }

}
