using NUnit.Framework;
using Game;

namespace Tests
{
	[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal sealed class PlayerTest
    {
        private Board Board { get; set; }
        private Player Player { get; set; }

        [SetUp]
        public void Start()
        {
            // Initialize map as
            // iOg
            // iwO
            // OOO
            Board = new Board(3, 3, "00g" + "0w0" + "000", 3);
            Board.AddItem(0, 0, 2);
            Board.AddItem(1, 0, 4);
            Player = new Player
            {
                Row = 0,
                Col = 1
            };
        }

        [Test]
        public void CanMoveInDirection_OutOfBounds()
        {
            var canMove = Player.CanMoveInDirection(Board, Direction.North);
            Assert.IsFalse(canMove, "You cannot move outside the map.");
        }

        [Test]
        public void CanMoveInDirection_OnWall()
        {
            var canMove = Player.CanMoveInDirection(Board, Direction.South);
            Assert.IsFalse(canMove, "You cannot move to a cell occupied by a wall.");
        }

        [Test]
        public void CanMoveInDirection_OnItem()
        {
            var canMove = Player.CanMoveInDirection(Board, Direction.West);
            Assert.IsTrue(canMove, "You can move to a cell occupied by an item.");
        }

        [Test]
        public void CanMoveInDirection_OnGoal()
        {
            var canMove = Player.CanMoveInDirection(Board, Direction.East);
            Assert.IsTrue(canMove, "You can move to a cell occupied by a goal.");
        }

        [Test]
        public void CanMoveInDirection_OnEmpty()
        {
            // Move the player so it can move towards empty cells
            Player.Row = 2;
            Player.Col = 1;

            var canMove = Player.CanMoveInDirection(Board, Direction.West);
            Assert.IsTrue(canMove, "You can move to an empty cell.");
        }

        [Test]
        public void Move_OutOfBounds()
        {
            var canMove = Player.Move(Board, Direction.North);
            Assert.IsFalse(canMove, "You cannot move outside the map.");
        }

        [Test]
        public void Move_OnWall()
        {
            var canMove = Player.Move(Board, Direction.South);
            Assert.IsFalse(canMove, "You cannot move to a cell occupied by a wall.");
        }

        [Test]
        public void Move_OnItem()
        {
            var canMove = Player.Move(Board, Direction.West);
            Assert.IsTrue(canMove, "You can move to a cell occupied by an item.");
            Assert.AreEqual(Player.Row, 0, "The item is at position (0, 0).");
            Assert.AreEqual(Player.Col, 0, "The item is at position (0, 0).");
        }

        [Test]
        public void Move_OnGoal()
        {
            var canMove = Player.Move(Board, Direction.East);
            Assert.IsTrue(canMove, "You can move to a cell occupied by a goal.");
            Assert.AreEqual(Player.Row, 0, "The item is at position (0, 2).");
            Assert.AreEqual(Player.Col, 2, "The item is at position (0, 2).");
        }

        [Test]
        public void Move_OnEmpty()
        {
            // Move the player so it can move towards empty cells
            Player.Row = 2;
            Player.Col = 1;

            var canMove = Player.Move(Board, Direction.West);
            Assert.IsTrue(canMove, "You can move to an empty cell.");
            Assert.AreEqual(Player.Row, 2, "(2, 1) + Direction.West = (2, 0)");
            Assert.AreEqual(Player.Col, 0, "(2, 1) + Direction.West = (2, 0)");
        }

        [Test]
        public void Move_PickItemOnEmpty()
        {
            var picked = Player.PickItem(Board);
            Assert.IsFalse(picked, "You cannot take an item from an empty cell.");
        }

        [Test]
        public void Move_PickItemOnGoal()
        {
            // Move the player to the position of a goal cell
            Assert.IsTrue(Player.Move(Board, Direction.East));

            var picked = Player.PickItem(Board);
            Assert.IsFalse(picked, "You cannot take an item from a goal cell.");
        }

        [Test]
        public void Move_PickItemOnItem()
        {
            // Move the player to the position of an item cell
            Assert.IsTrue(Player.Move(Board, Direction.West));
            Assert.IsTrue(Board.ContainsItem(0, 0));

            var picked = Player.PickItem(Board);
            Assert.IsTrue(picked, "You can take an item from an item cell.");

            // Drop the item to reset the state, and reset the Player's position.
            // NOTE: If this does not produce the correct behaviour, other tests will catch it.
            Assert.IsTrue(Player.DropItem(Board));
            Assert.IsTrue(Player.Move(Board, Direction.East));
        }

        [Test]
        public void InventoryValue_Empty()
        {
            var count = Player.InventoryValue(Board);
            Assert.AreEqual(count, 0, "The bag is empty, therefore the inventory value must be 0.");
        }

        [Test]
        public void InventoryValue_NotEmpty()
        {
            // Move the player to the position of an item cell
            Assert.IsTrue(Player.Move(Board, Direction.West));
            Assert.IsTrue(Player.PickItem(Board));

            var count = Player.InventoryValue(Board);

            Assert.AreEqual(count, 2, "The value of the item picked (at (0, 0)) is 2, therefore this should be 2.");

            // Drop the item to reset the state, and reset the Player's position.
            Assert.IsTrue(Player.DropItem(Board));
            Assert.IsTrue(Player.Move(Board, Direction.East));
        }

        [Test]
        public void InventoryValue_NotEmptyAccumulative()
        {
            // (1, 0) -> (0, 0)
            Assert.IsTrue(Player.Move(Board, Direction.West));
            Assert.IsTrue(Player.PickItem(Board));
            Assert.AreEqual(Player.InventoryValue(Board), 2, "The value of the item picked (at (0, 0)) is 2, therefore this should be 2.");

            // (0, 0) -> (0, 1)
            Assert.IsTrue(Player.Move(Board, Direction.South));
            Assert.IsTrue(Player.PickItem(Board));
            Assert.AreEqual(Player.InventoryValue(Board), 6, "The value of the item picked (at (0, 1)) is 4, therefore this should be 4 + 2.");

            // Drop the items to reset the state, and reset the Player's position.
            Assert.IsTrue(Player.DropItem(Board));
            Assert.IsTrue(Player.Move(Board, Direction.North));
            Assert.IsTrue(Player.DropItem(Board));
            Assert.IsTrue(Player.Move(Board, Direction.East));
        }

        [Test]
        public void GoalReached_OnEmpty()
        {
            // The player is in the position (1, 0), which is an empty cell.
            var reached = Player.GoalReached(Board);
            Assert.IsFalse(reached, "The player is not in a goal cell.");
        }

        [Test]
        public void GoalReached_OnItem()
        {
            // Move the player to the position of an item cell
            Assert.IsTrue(Player.Move(Board, Direction.West));

            var reached = Player.GoalReached(Board);
            Assert.IsFalse(reached, "The player is in an item cell, but not in a goal cell.");
        }

        [Test]
        public void GoalReached_OnGoal()
        {
            // Move the player to the position of a goal cell
            Assert.IsTrue(Player.Move(Board, Direction.East));

            var reached = Player.GoalReached(Board);
            Assert.IsTrue(reached, "The player is in a goal cell, therefore this should be true.");
        }

        [Test]
        public void DropItem_Empty()
        {
            var dropped = Player.DropItem(Board);
            Assert.IsFalse(dropped, "The player does not have an item to drop.");
        }

        [Test]
        public void DropItem_Available()
        {
            Assert.IsTrue(Player.Move(Board, Direction.West));
            Assert.IsTrue(Player.PickItem(Board));
            Assert.IsFalse(Board.ContainsItem(0, 0));

            var dropped = Player.DropItem(Board);
            Assert.IsTrue(dropped, "The player had an item and successfully dropped it in an empty cell.");
        }

        [Test]
        public void DropItem_Unavailable()
        {
            Assert.IsTrue(Player.Move(Board, Direction.West));
            Assert.IsTrue(Player.PickItem(Board));
            Assert.IsFalse(Board.ContainsItem(0, 0));
            Assert.IsTrue(Player.Move(Board, Direction.South));
            Assert.IsTrue(Board.ContainsItem(1, 0));

            var dropped = Player.DropItem(Board);
            Assert.IsFalse(dropped, "The player had an item but it cannot drop it in an occupied cell.");

            Assert.IsTrue(Player.Move(Board, Direction.North));
            Assert.IsTrue(Player.DropItem(Board));
        }
    }
}