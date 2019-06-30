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

        private int _itemsCount;

        /// <summary>
        /// Creates a new board. 
        /// </summary>
        /// <param name="row">Number of rows</param>
        /// <param name="col">Number of columns</param>
        /// <param name="textMap">String of size r*c that represents the map (walls, goals and empty spaces)</param>
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
                    if (ch == 'i') AddItem(r, c, _itemsCount);
                    ++aux;
                }
            }
        }

        /// <summary>
        /// Checks if there is a wall in a position. If the position is out of bounds it returns the same 
        /// result as if a wall was there.
        /// </summary>
        /// <returns>True if there  is a wall in position (r,c); false, otherwise</returns>
        /// <param name="col">row</param>
        /// <param name="row">column</param>
        public bool IsWallAt(int row, int col)
        {
            return col < 0 || row >= _rows || row < 0 || col >= _cols || _map[row, col] == 'w';
        }

        /// <summary>
        /// Checks if there is an item in a position. If the position is out of bounds it returns false
        /// </summary>
        /// <returns><c>true</c> if there  is an item in position (r,c); <c>false</c> otherwise</returns>
        /// <param name="col">row</param>
        /// <param name="row">column</param>
        public bool ContainsItem(int row, int col)
        {
            var found = false;
            var i = 0;
            while (!found && i < _itemsCount)
            {
                var item = _itemsInBoard[i];
                if (item.Row == row && item.Col == col)
                {
                    found = true;
                }
                else
                {
                    i++;
                }
            }

            return found;
        }

        /// <summary>
        /// Adds an item with a value in a position The position must be inside board bounds and iw
        /// t must be empty.
        /// The map should be updated with the new edded item.
        /// It throws an exception if the maximum number of items was exceeded.
        /// </summary>
        /// <returns><c>true</c>, if the item was added; <c>false</c> otherwise.</returns>
        /// <param name="col">Row</param>
        /// <param name="row">Column</param>
        /// <param name="value">Item value</param>
        public bool AddItem(int row, int col, int value)
        {
            if (row < 0 || row >= _rows || col < 0 || col >= _cols) return false;
            if (_itemsCount == _itemsInBoard.Length || _map[row, col] != 'O') return false;

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
        /// <returns>
        /// The position of the item in the itemsInBoard array, 
        /// or -1 if there is not any item in that position
        /// </returns>
        /// <param name="row">Row</param>
        /// <param name="col">Column</param>
        public int PickItem(int row, int col)
        {
            var numReturn = -1;
            if (!ContainsItem(row, col)) return numReturn;

            var aux = 0;
            while (aux < _itemsCount)
            {
                if (_itemsInBoard[aux].Row == row && _itemsInBoard[aux].Col == col)
                {
                    _map[row, col] = 'O';
                    numReturn = _itemsInBoard[aux].Value;

                    // If an item was found, move all the items ahead to the previous
                    // index and reduce itemsCount by one.
                    --_itemsCount;
                    for (; aux < _itemsCount; ++aux)
                    {
                        _itemsInBoard[aux] = _itemsInBoard[aux + 1];
                    }
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
        /// <returns><c>true</c> if the position is a goal, <c>false</c> otherwise</returns>
        /// <param name="row">Row</param>
        /// <param name="col">Column</param>
        public bool IsGoalAt(int row, int col)
        {
            return _map[row, col] == 'g';
        }

        /// <summary>
        /// Gets the i-th item in the itemsInBoard array. It throws an exception if the item does not exist.
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <returns>The item</returns>
        /// <param name="i">The index in the itemsInBoard array</param>
        public Item GetItem(int i)
        {
            if (i < _itemsCount)
            {
                return _itemsInBoard[i];
            }

            throw new Exception("Item index error.");
        }

        public bool DropItem(int row, int col, int item)
        {
            if (row < 0 || row >= _rows || col < 0 || col >= _cols || _map[row, col] != 'O') return false;

            // Cannot expand, this is a guard to avoid out-of-bounds exceptions.
            if (_itemsCount == _itemsInBoard.Length) return false;

            _map[row, col] = 'i';
            _itemsInBoard[_itemsCount].Value = item;
            _itemsInBoard[_itemsCount].Col = col;
            _itemsInBoard[_itemsCount].Row = row;
            ++_itemsCount;
            return true;
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
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("0");
                            break;
                        case 'w':
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("w");
                            break;
                        case 'i':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("i");
                            break;
                        case 'g':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("g");
                            break;
                        default:
                            throw new NotImplementedException("Unreachable.");
                    }

                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }
    }
}