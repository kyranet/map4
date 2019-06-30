using NUnit.Framework;
using System;
using Game;

namespace Tests
{
    internal sealed class BoardTest
    {
        private Board Board { get; set; }

        [SetUp]
        public void Start()
        {
            // Initialize map as
            // iOg
            // iwO
            // OOO
            Board = new Board(3, 3, "OOg" + "OwO" + "OOO", 3);
            Board.AddItem(0, 0, 2);
            Board.AddItem(0, 1, 4);
        }

        [Test]
        public void IsWallAt_OutOfBounds()
        {
            var isWall = Board.IsWallAt(-1, 0);
            Assert.IsTrue(isWall, "Position outside the map are considered walls");
        }

        [Test]
        public void IsWallAt_Exists()
        {
            var isWall = Board.IsWallAt(1, 1);
            Assert.IsTrue(isWall, "You do not detect a wall when you should detect it.");
        }

        [Test]
        public void IsWallAt_NotExists()
        {
            var isWall = Board.IsWallAt(0, 1);
            Assert.IsFalse(isWall, "You have detected a wall when you should not.");
        }

        [Test]
        public void ContainsItem_OutOfBounds()
        {
            var hasItem = Board.ContainsItem(-1, 0);
            Assert.IsFalse(hasItem, "You can not place items outside the limits");
        }

        [Test]
        public void ContainsItem_Exists()
        {
            var hasItem = Board.ContainsItem(0, 0);
            Assert.IsTrue(hasItem, "There is an item at (0, 0).");
        }

        [Test]
        public void ContainsItem_NotExists()
        {
            var hasItem = Board.ContainsItem(2, 2);
            Assert.IsFalse(hasItem, "You have detected an item in a position where there is no item");
        }

        [Test]
        public void AddItem_OutOfBounds()
        {
            var canAdd = Board.AddItem(-1, -1, 1);
            Assert.False(canAdd, "You have added an item outside the limits of the map");
        }

        [Test]
        public void AddItem_Exists()
        {
            var canAdd = Board.AddItem(1, 0, 1);
            Assert.True(canAdd, "You could not add an item in a position where you could.");
        }

        [Test]
        public void AddItem_OnWall()
        {
            var canAdd = Board.AddItem(1, 1, 1);
            Assert.False(canAdd, "You have added an item on a wall");
        }

        [Test]
        public void AddItem_OnGoal()
        {
            var canAdd = Board.AddItem(0, 2, 1);
            Assert.False(canAdd, "You have added an item to the position of a goal");
        }

        [Test]
        public void PickItem_Exists()
        {
            var aux = Board.PickItem(0, 0);
            var canPickIt = aux != -1;
            Assert.True(canPickIt, "You have not been able to pick up an item when you could.");
        }

        [Test]
        public void PickItem_NoExists()
        {
            var aux = Board.PickItem(1, 0);
            var canPickIt = aux != -1;
            Assert.False(canPickIt, "You have taken an item that does not exist on the map.");
        }

        [Test]
        public void IsGoal_Exists()
        {
            var isGoal = Board.IsGoalAt(0, 2);
            Assert.True(isGoal, "You have not been able to finish the game by touching a goal.");
        }

        [Test]
        public void IsGoal_NoExists()
        {
            var isGoal = Board.IsGoalAt(2, 2);
            Assert.False(isGoal, "You have finished the game when you have not touched a goal.");
        }

        [Test]
        public void GetItem_OutOfBounds()
        {
            Assert.Throws<Exception>(() => { Board.GetItem(3); },
                "you have taken an item outside the limits of the map ");
        }

        [Test]
        public void DropItem_Empty()
        {
            Assert.IsFalse(Board.ContainsItem(2, 2), "The cell should be initially empty");
            Assert.IsTrue(Board.DropItem(2, 2, 1), "As the cell is empty, the item should be dropped");
            Assert.IsTrue(Board.ContainsItem(2, 2), "As the cell is not longer empty, this should be true");
        }

        [Test]
        public void DropItem_NotEmptyWall()
        {
            Assert.IsFalse(Board.ContainsItem(1, 1));
            Assert.IsFalse(Board.DropItem(1, 1, 1));
            Assert.IsFalse(Board.ContainsItem(1, 1));
        }

        [Test]
        public void DropItem_NotEmptyGoal()
        {
            Assert.IsFalse(Board.ContainsItem(0, 2), "There cannot be an item in the goal");
            Assert.IsFalse(Board.DropItem(0, 2, 1), "It is not possible to drop an item in the goal");
            Assert.IsFalse(Board.ContainsItem(0, 2),
                "As it is not possible to drop an item here, it should be false");
        }
    }
}