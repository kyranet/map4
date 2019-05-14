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
            Assert.IsTrue(canMove, "You have moved off the map");
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
            Assert.IsTrue(canMove, "you have moved on a wall");
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
            Assert.IsFalse(canMove, "You can´t move on an item");
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
            Assert.IsTrue(canMove, "You can´t make a normal movement");
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
            Assert.IsFalse(canMove, "You have been moved out of map");
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
            Assert.IsFalse(canMove, "You have moved on a wall");
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
            Assert.IsFalse(canMove, "You have moved on a wall");
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
            Assert.IsFalse(canMove, "You can´t move on a item");
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
            Assert.IsFalse(picked, "You have taken an item where there is no one");
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
            Assert.IsTrue(picked, "You can´t pick item in normal conditions");
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
            Assert.IsFalse(picked, "You have taken an item on a wall");
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
            Assert.IsFalse(picked, "You have taken an item on an item");
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

            Assert.AreEqual(count, 0, "The value of your inventory is different from zero when you should not");
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

            Assert.AreEqual(count, expected, "The value of your inventory is zero when it should be greater than zero");
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
            theBoard.AddItem(0, 1, expected);

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

            Assert.IsFalse(currPlayer.GoalReached(theBoard), "You have reached a goal when you should not.");
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

            Assert.IsFalse(currPlayer.GoalReached(theBoard), "You have reached an item in an empty space.");
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

            Assert.IsFalse(currPlayer.GoalReached(theBoard), "You have reached a goal when you were on a wall.");
        }

        [Test]
        public void GoalReached_True()
        {
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "gO0" +
                "OwO" +
                "OOO",
                3);

            Assert.IsTrue(currPlayer.GoalReached(theBoard), "You have not reached a goal when you should have reached it.");
        }

        [Test]
        public void DropItem_Empty()
        {
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                3);

            Assert.IsFalse(currPlayer.DropItem(theBoard),"");
        }

        [Test]
        public void DropItem_Available()
        {
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "iOg" +
                "OwO" +
                "OOO",
                1);

            Assert.IsTrue(currPlayer.PickItem(theBoard));
            Assert.IsFalse(theBoard.ContainsItem(0, 0));
            Assert.IsTrue(currPlayer.DropItem(theBoard));
            Assert.IsTrue(theBoard.ContainsItem(0, 0));
        }

        [Test]
        public void DropItem_Unavailable()
        {
            var currPlayer = new Player();
            var theBoard = new Board(3, 3,
                "OOg" +
                "OwO" +
                "OOO",
                2);
            theBoard.AddItem(0, 0, 1);
            theBoard.AddItem(0, 1, 2);

            Assert.IsTrue(currPlayer.PickItem(theBoard), "There is an item");
            Assert.IsFalse(theBoard.ContainsItem(0, 0), "The item should be picked, therefore removed");
            Assert.IsTrue(currPlayer.Move(theBoard, Direction.South), "There is no obstacle in the south");
            Assert.IsTrue(theBoard.ContainsItem(0, 1), "There is an item in this place");
            Assert.IsFalse(currPlayer.DropItem(theBoard), "It should not be possible to drop an item here, as it is occupied");
        }
    }

}
