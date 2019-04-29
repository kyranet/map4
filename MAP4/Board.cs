using System;

namespace Game
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    };

    public struct Item
    {
        public int Value;
        public int Row;
        public int Col;
    }

    public class Board
    {
        /// <summary>
        /// Matrix of chars that represent the board:
        /// - 0: Empty space
        /// - w: Wall
        /// - i: Item
        /// - g: Goal
        /// </summary>
        private readonly char[,] _map;

        /// <summary>
        /// Number of rows of the map
        /// </summary>
        private readonly int _rows;

        /// <summary>
        /// Number of cols of the map
        /// </summary>
        private readonly int _cols;

        /// <summary>
        /// Array with the items contained in this board
        /// </summary>
        private readonly Item[] _itemsInBoard;

        private int _itemsCount = 0;

        /// <summary>
        /// Creates a new board. 
        /// </summary>
        /// <param name="r">Number of rows</param>
        /// <param name="c">Number of columns</param>
        /// <param name="textMap">String of size r*c that represents the map (walls, goals and empty spaces)</param>
        /// <param name="maxItems">Max number of items contained in the board.</param>
        public Board(int r, int c, string textMap, int maxItems)
        {
            _rows = r;
            _cols = c;
            _map = new char[r, c];
            int aux = 0;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    _map[i, j] = textMap[aux];
                }
            }

            _itemsInBoard = new Item[maxItems];
        }

        /// <summary>
        /// Checks if there is a wall in a position. If the position is out of bounds it returns the same 
        /// result as if a wall was there.
        /// </summary>
        /// <returns>True if there  is a wall in position (r,c); false, otherwise</returns>
        /// <param name="r">row</param>
        /// <param name="c">column</param>
        public bool IsWallAt(int r, int c)
        {
            return r >= 0 && r < _rows && c >= 0 && c < _cols || _map[r, c] == 'w';
        }

        /// <summary>
        /// Checks if there is an item in a position. If the position is out of bounds it returns false
        /// </summary>
        /// <returns><c>true</c> if there  is an item in position (r,c); <c>false</c> otherwise</returns>
        /// <param name="r">row</param>
        /// <param name="c">column</param>
        public bool ContainsItem(int r, int c)
        {
            if (IsWallAt(r, c)) return false;
            bool found = false;
            int i = 0;
            while (!found && i < _itemsCount)
            {
                var item = _itemsInBoard[i];
                if (item.Row == r && item.Col == c)
                {
                    found = true;
                }
            }

            return found;
        }

        /// <summary>
        /// Adds an item with a value in a position The position must be inside board bounds and it must be empty.
        /// The map should be updated with the new edded item.
        /// It throws an exception if the maximum number of items was exceeded.
        /// </summary>
        /// <returns><c>true</c>, if the item was added; <c>false</c> otherwise.</returns>
        /// <param name="r">Row</param>
        /// <param name="c">Column</param>
        /// <param name="value">Item value</param>
        public bool AddItem(int r, int c, int value)
        {
            if (IsWallAt(r, c) || _itemsCount == _itemsInBoard.Length) return false;

            var currItem = new Item
            {
                Col = c, Row = r, Value = value
            };
            _itemsInBoard[_itemsCount++] = currItem;
            return true;
        }

        /// <summary>
        /// Picks an item in a position, if it exists
        /// </summary>
        /// <returns>
        /// The position of the item in the itemsInBoard array, 
        /// or -1 if there is not any item in that position
        /// </returns>
        /// <param name="r">Row</param>
        /// <param name="c">Column</param>
        public int PickItem(int r, int c)
        {
        }


        /// <summary>
        /// Checks if a position is a goal
        /// </summary>
        /// <returns><c>true</c> if the position is a goal, <c>false</c> otherwise</returns>
        /// <param name="row">Row</param>
        /// <param name="col">Column</param>
        public bool IsGoalAt(int row, int col)
        {
        }

        /// <summary>
        /// Gets the i-th item in the itemsInBoard array. It throws an exception if the item does not exist.
        /// </summary>
        /// <returns>The item</returns>
        /// <param name="i">The index in the itemsInBoard array</param>
        public Item GetItem(int i)
        {
        }
    }
}