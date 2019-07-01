using System;

namespace Game
{
    public class Player
    {
        /// <summary>
        /// Player position in rows.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Player position in columns.
        /// </summary>
        public int Col { get; set; }

        /// <summary>
        /// A bag containing the items collected.
        /// </summary>
        private readonly Lista _bag;

        /// <summary>
        /// The player starts at 0,0 and with an empty bag.
        /// </summary>
        public Player()
        {
            Row = 0;
            Col = 0;
            _bag = new Lista();
        }

        /// <summary>
        /// Checks if the player can move one step in a concrete direction in a board. The player can move is 
        /// the next position in this direction is not a wall.
        /// </summary>
        /// <param name="aBoard">The board where the player is moving.</param>
        /// <param name="dir">Movement direction.</param>
        /// <returns><c>true</c>, if the player can move, <c>false</c> otherwise.</returns>
        public bool CanMoveInDirection(Board aBoard, Direction dir)
        {
            int x = Col, y = Row;
            switch (dir)
            {
                case Direction.East:
                    ++x;
                    break;
                case Direction.West:
                    --x;
                    break;
                case Direction.North:
                    --y;
                    break;
                case Direction.South:
                    ++y;
                    break;
                default:
                    throw new NotImplementedException("Unreachable.");
            }

            return !aBoard.IsWallAt(x, y);
        }

        /// <summary>
        /// Moves the player along a direction until it collides with a wall. 
        /// Player position is updated when the movement finishes.
        /// Returns whether the player has moved at least one position.
        /// </summary>
        /// <param name="aBoard">The board where the player is moving.</param>
        /// <param name="dir">Movement direction.</param>
        /// <returns><c>true</c>, if the player has moved at least one position, <c>false</c> otherwise.</returns>
        public bool Move(Board aBoard, Direction dir)
        {
            if (!CanMoveInDirection(aBoard, dir)) return false;
            switch (dir)
            {
                case Direction.East:
                    ++Col;
                    break;
                case Direction.West:
                    --Col;
                    break;
                case Direction.North:
                    --Row;
                    break;
                case Direction.South:
                    ++Row;
                    break;
                default:
                    throw new NotImplementedException("Unreachable.");
            }

            return true;
        }

        /// <summary>
        /// Try to pick an item contained in player's position and store it in the bag.
        /// </summary>
        /// <param name="aBoard">The board where the player is moving.</param>
        /// <returns><c>true</c>, if there is an item in player's position <c>false</c> otherwise.</returns>
        public bool PickItem(Board aBoard)
        {
            if (!aBoard.ContainsItem(Row, Col)) return false;
            _bag.InsertaFin(aBoard.PickItem(Row, Col));
            return true;
        }

        /// <summary>
        /// Tries to drop an item contained in the player's bag into the position, it can
        /// only drop the item picked in the player's current position.
        /// </summary>
        /// <param name="board">The board where the player is moving.</param>
        /// <returns><c>true</c>, if an item was dropped at the player's position <c>false</c> otherwise.</returns>
        public bool DropItem(Board board)
        {
            if (_bag.CuentaEltos() == 0) return false;

            var i = 0;
            var found = false;
            while (!found && i < _bag.CuentaEltos())
            {
                var value = _bag.NEsimo(i);
                var item = board.GetItem(value);
                if (item.Col == Col && item.Row == Row && board.DropItem(item))
                {
                    found = true;
                    _bag.BorraElto(value);
                }
                else
                {
                    ++i;
                }
            }

            return found;
        }

        /// <summary>
        /// Returns the total value of the items stored in player's bag.
        /// </summary>
        /// <returns>The sum of the values of the collected items.</returns>
        /// <param name="aBoard">The board where the player is moving.</param>
        /// <returns>The summed value of all items from the bag.</returns>
        public int InventoryValue(Board aBoard)
        {
            var total = 0;
            for (var i = 0; i < _bag.CuentaEltos(); i++)
            {
                total += aBoard.GetItem(_bag.NEsimo(i)).Value;
            }

            return total;
        }

        /// <summary>
        /// Checks if the player arrives at a goal position
        /// </summary>
        /// <param name="aBoard">The board where the player is moving.</param>
        /// <returns><c>true</c>, if the player position is a goal <c>false</c> otherwise.</returns>
        public bool GoalReached(Board aBoard)
        {
            return aBoard.IsGoalAt(Row, Col);
        }
    }
}