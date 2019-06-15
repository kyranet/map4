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
			var isWall = theBoard.IsWallAt(-1, 0);

			// Assert
			Assert.IsTrue(isWall, "Position outside the map are considered walls");
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
			Assert.IsTrue(isWall, "You do not detect a wall when you should detect it.");
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
			Assert.IsFalse(isWall, "You have detected a wall when you should not.");
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
			Assert.IsFalse(hasItem, "You can not place items outside the limits");
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
			Assert.IsTrue(hasItem, "You have detected a wall when you should not.");
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
			Assert.IsFalse(hasItem, "You have detected an item in a position where there is no item");
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
			bool canAdd = theBoard.AddItem(-1, -1, 1);

			// Assert
			Assert.False(canAdd, "You have added an item outside the limits of the map");
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
			Assert.True(canAdd, "You could not add an item in a position where you could.");
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
			Assert.False(canAdd, "You have added an item on a wall");
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
			Assert.False(canAdd, "You have added an item to the position of a goal");
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
			Assert.True(canPickIt, "You have not been able to pick up an item when you could.");
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
			Assert.False(canPickIt, "You have taken an item that does not exist on the map.");
		}

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
			Assert.True(isGoal, "You have not been able to finish the game by touching a goal.");
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
			Assert.False(isGoal, "You have finished the game when you have not touched a goal.");
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

			Assert.Throws<Exception>(() => { theBoard.GetItem(0); },
				"you have taken an item outside the limits of the map ");
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
			Assert.IsFalse(theBoard.ContainsItem(2, 0),
				"As it is not possible to drop an item here, it should be false");
		}
	}
}