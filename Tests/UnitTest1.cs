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
    }
}