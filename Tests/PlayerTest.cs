using System;
using System.Collections.Generic;
using System.Text;
using Game;
using NUnit.Framework;


namespace Tests
{
    class PlayerTest
    {
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
        public void Move_CanMove()
        {
            // Arrange
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "OgO" +
                "OwO" +
                "OOO",
                3);

            Assert.IsTrue(currPlayer.Move(theBoard, Direction.South), "Should be able to move South");
            Assert.AreEqual(currPlayer.Row, 1, "Should not change its Row");
            Assert.AreEqual(currPlayer.Col, 0, "Should change its Col to 1");
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

        [Test]
        public void Move_PickItemEmpty()
        {
            // Arrange
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "Oig" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool picked = currPlayer.PickItem(theBoard);

            // Assert
            Assert.IsFalse(picked, "Error");
        }

        [Test]
        public void Move_PickItemNotEmpty()
        {
            // Arrange
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "iOg" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool picked = currPlayer.PickItem(theBoard);

            // Assert
            Assert.IsTrue(picked, "Error");
        }

        [Test]
        public void Move_PickItemWall()
        {
            // Arrange
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "wig" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool picked = currPlayer.PickItem(theBoard);

            // Assert
            Assert.IsFalse(picked, "Error");
        }

        [Test]
        public void Move_PickItemGoal()
        {
            // Arrange
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "giw" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool picked = currPlayer.PickItem(theBoard);

            // Assert
            Assert.IsFalse(picked, "Error");
        }

        [Test]
        public void InventoryValue_Empty()
        {
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "iOg" +
                "OwO" +
                "OOO",
                3);

            var count = currPlayer.InventoryValue(theBoard);

            Assert.AreEqual(count, 0);
        }

        [Test]
        public void InventoryValue_NotEmpty()
        {
            var expected = 5;
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                3);
            theBoard.AddItem(0, 0, expected);
            currPlayer.PickItem(theBoard);
            var count = currPlayer.InventoryValue(theBoard);

            Assert.AreEqual(count, expected);
        }

        [Test]
        public void InventoryValue_NotEmptyAccumulative()
        {
            var expected = 5;
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                3);
            theBoard.AddItem(0, 0, expected);
            theBoard.AddItem(1, 0, expected);
            Assert.IsTrue(theBoard.ContainsItem(0, 0), "There must be an item in (0, 0)");
            Assert.IsTrue(theBoard.ContainsItem(1, 0), "There must be an item in (0, 1)");

            Assert.IsTrue(currPlayer.PickItem(theBoard), "Pick first item");
            Assert.IsTrue(currPlayer.Move(theBoard, Direction.South), "Move to south");
            Assert.IsTrue(currPlayer.PickItem(theBoard), "Pick second item");

            var count = currPlayer.InventoryValue(theBoard);

            Assert.AreEqual(count, expected + expected);
        }

        [Test]
        public void GoalReached_False()
        {
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                3);

            Assert.IsFalse(currPlayer.GoalReached(theBoard));
        }

        [Test]
        public void GoalReached_FalseItem()
        {
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                3);
            theBoard.AddItem(0, 0, 1);

            Assert.IsFalse(currPlayer.GoalReached(theBoard));
        }

        [Test]
        public void GoalReached_FalseWall()
        {
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "wOg" +
                "OwO" +
                "OOO",
                3);

            Assert.IsFalse(currPlayer.GoalReached(theBoard));
        }

        [Test]
        public void GoalReached_True()
        {
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "gOg" +
                "OwO" +
                "OOO",
                3);

            Assert.IsTrue(currPlayer.GoalReached(theBoard));
        }
    }

}
