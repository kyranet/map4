using NUnit.Framework;
using Game;
using System;

namespace Tests
{
    public class BoardTest
    {
        [Test]
        public void IsWallAt_OutOfBounds()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool isWall = theBoard.IsWallAt(-1, 0);

            // Assert
            Assert.IsTrue(isWall, "Error");
        }

        [Test]
        public void IsWallAt_Exists()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool isWall = theBoard.IsWallAt(1, 1);

            // Assert
            Assert.IsTrue(isWall, "Error");
        }

        [Test]
        public void IsWallAt_NotExists()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool isWall = theBoard.IsWallAt(0, 1);

            // Assert
            Assert.IsFalse(isWall, "Error");
        }

        [Test]
        public void ContainsItem_OutOfBounds()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "iOO",
                3);

            // Act
            bool hasItem = theBoard.ContainsItem(-1, 0);

            // Assert
            Assert.IsFalse(hasItem, "Error");
        }

        [Test]
        public void ContainsItem_Exists()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "iOO",
                3);

            // Act
            bool hasItem = theBoard.ContainsItem(0, 2);

            // Assert
            Assert.IsTrue(hasItem, "Error");
        }

        [Test]
        public void ContainsItem_NotExists()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "iOO",
                3);

            // Act
            bool hasItem = theBoard.ContainsItem(0, 0);

            // Assert
            Assert.IsFalse(hasItem, "Error");
        }

        [Test]
        public void AddItem_OutOfBounds()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool canAdd = theBoard.AddItem(-1, -1,1);

            // Assert
            Assert.False(canAdd, "Error");
        }

        [Test]
        public void AddItem_Exists()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool canAdd = theBoard.AddItem(1, 0, 1);

            // Assert
            Assert.True(canAdd, "Error");
        }

        [Test]
        public void AddItem_OnWall()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool canAdd = theBoard.AddItem(1, 1, 1);

            // Assert
            Assert.False(canAdd, "Error");
        }
        [Test]
        public void AddItem_OnGoal()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                3);

            // Act
            bool canAdd = theBoard.AddItem(2, 0, 1);

            // Assert
            Assert.False(canAdd, "Error");
        }

        [Test]
        public void PickItem_Exists()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOi",
                3);

            // Act
            var aux = theBoard.PickItem(2, 2);
            bool canPickIt = aux != -1;

            // Assert
            Assert.True(canPickIt, "Error");
        }
        [Test]
        public void PickItem_NoExists()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "iOO",
                3);

            // Act
            var aux = theBoard.PickItem(0, 1);
            bool canPickIt = aux != -1;

            // Assert
            Assert.False(canPickIt, "Error");
        }
        /*[Test]
        public void IsGoal_OutOfBounds()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "iOO",
                3);

            // Act
            var isGoal = theBoard.IsGoalAt(-1, -1);

            // Assert
            Assert.False(isGoal, "Error");
        }*/

        [Test]
        public void IsGoal_Exists()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "iOO",
                3);

            // Act
            var isGoal = theBoard.IsGoalAt(2, 0);

            // Assert
            Assert.True(isGoal, "Error");
        }

        [Test]
        public void IsGoal_NoExists()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "iOO",
                3);

            // Act
            var isGoal = theBoard.IsGoalAt(2, 2);

            // Assert
            Assert.False(isGoal, "Error");
        }

        [Test]
        public void GetItem_OutOfBounds()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                0);

            Assert.Throws<Exception>(() =>
            {
                theBoard.GetItem(0);
            });
        }

        [Test]
        public void DropItem_Empty()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                1);

            Assert.IsFalse(theBoard.ContainsItem(0, 0), "The cell should be initially empty");
            Assert.IsTrue(theBoard.DropItem(0, 0, 1), "As the cell is empty, the item should be dropped");
            Assert.IsTrue(theBoard.ContainsItem(0, 0), "As the cell is not longer empty, this should be true");
        }

        [Test]
        public void DropItem_NotEmptyWall()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "iOg" +
                "OwO" +
                "OOO",
                1);

            Assert.IsFalse(theBoard.ContainsItem(1, 1));
            Assert.IsFalse(theBoard.DropItem(1, 1, 1));
            Assert.IsFalse(theBoard.ContainsItem(1, 1));
        }

        [Test]
        public void DropItem_NotEmptyGoal()
        {
            // Arrange
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                1);

            Assert.IsFalse(theBoard.ContainsItem(2, 0), "There cannot be an item in the goal");
            Assert.IsFalse(theBoard.DropItem(2, 0, 1), "It is not possible to drop an item in the goal");
            Assert.IsFalse(theBoard.ContainsItem(2, 0), "As it is not possible to drop an item here, it should be false");
        }
    }
}