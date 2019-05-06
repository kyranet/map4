using NUnit.Framework;
using Game;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

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


    }
}