using System;

namespace Game
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }

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
        /// Number of rows of the map.
        /// </summary>
        private readonly int _rows;

        /// <summary>
        /// Number of cols of the map.
        /// </summary>
        private readonly int _cols;

        /// <summary>
        /// Array with the items contained in this board.
        /// </summary>
        private readonly Item[] _itemsInBoard;

        private int _itemsCount;

        /// <summary>
        /// Creates a new board. 
        /// </summary>
        /// <param name="row">Number of rows.</param>
        /// <param name="col">Number of columns.</param>
        /// <param name="textMap">String of size (r * c) that represents the map (walls, goals and empty spaces).</param>
        /// <param name="maxItems">Max number of items contained in the board.</param>
        public Board(int row, int col, string textMap, int maxItems)
        {
            _rows = row;
            _cols = col;
            _itemsCount = 0;
            _map = new char[row, col];
            _itemsInBoard = new Item[maxItems];
            var aux = 0;
            for (var r = 0; r < row; r++)
            {
                for (var c = 0; c < col; c++)
                {
                    var ch = textMap[aux];
                    _map[r, c] = ch;
                    ++aux;
                }
            }
        }

        /// <summary>
        /// Checks if there is a wall in a position. If the position is out of bounds it returns the same 
        /// result as if a wall was there.
        /// </summary>
        /// <param name="row">The row to check the wall at.</param>
        /// <param name="col">The column to check the wall at.</param>
        /// <returns><c>true</c>, if the position contains a wall, <c>false</c> otherwise.</returns>
        public bool IsWallAt(int row, int col)
        {
            return row < 0 || row >= _rows || col < 0 || col >= _cols || _map[row, col] == 'w';
        }

        /// <summary>
        /// Checks if there is an item in a position. If the position is out of bounds it returns false
        /// </summary>
        /// <param name="row">The row to check the item at.</param>
        /// <param name="col">The column to check the item at.</param>
        /// <returns><c>true</c>, if the position contains an item, <c>false</c> otherwise.</returns>
        public bool ContainsItem(int row, int col)
        {
            return row >= 0 && row < _rows && col >= 0 && col < _cols && _map[row, col] == 'i';
        }

        /// <summary>
        /// Adds an item with a value in a position The position must be inside board bounds and iw
        /// t must be empty.
        /// The map should be updated with the new edded item.
        /// It throws an exception if the maximum number of items was exceeded.
        /// </summary>
        /// <param name="row">The row to put the item at.</param>
        /// <param name="col">The column to put the item at.</param>
        /// <param name="value">The value for the item.</param>
        /// <returns><c>true</c>, if the item was successfully added, <c>false</c> otherwise.</returns>
        public bool AddItem(int row, int col, int value)
        {
            if (row < 0 || row >= _rows || col < 0 || col >= _cols) return false;
            if (_itemsCount == _itemsInBoard.Length || _map[row, col] != '0') return false;

            var currItem = new Item
            {
                Col = col,
                Row = row,
                Value = value
            };
            _map[row, col] = 'i';
            _itemsInBoard[_itemsCount++] = currItem;
            return true;
        }

        /// <summary>
        /// Picks an item in a position, if it exists
        /// </summary>
        /// <param name="row">The row to check the item at.</param>
        /// <param name="col">The column to check the item at.</param>
        /// <returns>
        /// The position of the item in the <c>_itemsInBoard</c> array, 
        /// or -1 if there is not any item in that position.
        /// </returns>
        public int PickItem(int row, int col)
        {
            var numReturn = -1;
            if (!ContainsItem(row, col)) return numReturn;

            var stop = false;
            var aux = 0;
            while (!stop && aux < _itemsCount)
            {
                if (_itemsInBoard[aux].Row == row && _itemsInBoard[aux].Col == col)
                {
                    _map[row, col] = '0';
                    numReturn = aux;
                    stop = true;
                }
                else
                {
                    aux++;
                }
            }

            return numReturn;
        }


        /// <summary>
        /// Checks if a position is a goal
        /// </summary>
        /// <param name="row">The row to check the goal at.</param>
        /// <param name="col">The column to check the goal at.</param>
        /// <returns><c>true</c>, if the position contains a goal, <c>false</c> otherwise.</returns>
        public bool IsGoalAt(int row, int col)
        {
            return row >= 0 && row < _rows && col >= 0 && col < _cols && _map[row, col] == 'g';
        }

        /// <summary>
        /// Gets the i-th item in the itemsInBoard array. It throws an exception if the item does not exist.
        /// </summary>
        /// <param name="i">The index in the <c>_itemsInBoard</c> array.</param>
        /// <returns>The item</returns>
        /// <exception cref="Exception">When the index is either negative or equals or greater than <c>_itemsCount</c>.</exception>
        public Item GetItem(int i)
        {
            if (i >= 0 && i < _itemsCount)
            {
                return _itemsInBoard[i];
            }

            throw new Exception("Item index error.");
        }

        /// <summary>
        /// Drops an item to the board.
        /// </summary>
        /// <param name="item">The Item instance to be dropped into the board.</param>
        /// <returns><c>true</c> if it was successfully dropped into the board, <c>false</c> otherwise.</returns>
        /// <exception cref="IndexOutOfRangeException">When the item has malformed <c>Row</c> and or <c>Col</c> values.</exception>
        public bool DropItem(Item item)
        {
            var existent = _map[item.Row, item.Col];
            var dropped = false;
            if (existent == '0')
            {
                _map[item.Row, item.Col] = 'i';
                dropped = true;
            }

            return dropped;
        }

        /// <summary>
        /// Print map in console
        /// </summary>
        public void PrintMap()
        {
            Console.Clear();
            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _cols; j++)
                {
                    switch (_map[i, j])
                    {
                        case '0':
                            Console.Write("0");
                            break;
                        case 'w':
                            Console.Write("w");
                            break;
                        case 'i':
                            Console.Write("i");
                            break;
                        case 'g':
                            Console.Write("g");
                            break;
                        default:
                            throw new NotImplementedException("Unreachable.");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}