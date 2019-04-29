using System;
using Listas;
namespace Game
{
    public class Player
    {
        /// <summary>
        /// Player position
        /// </summary>
        int row, col;

        /// <summary>
        /// A bag containing the items collected
        /// </summary>
        Lista bag;

        /// <summary>
        /// The number collected items in the bag.
        /// </summary>
        int numCollectedItems;

        /// <summary>
        /// The player starts at 0,0 and with an empty bag
        /// </summary>
        public Player()
        {

        }

        /// <summary>
        /// Checks if the player can move one step in a concrete direction in a board. The player can move is 
        /// the next position in this direction is not a wall
        /// </summary>
        /// <returns><c>true</c>, if the player can move, <c>false</c> otherwise.</returns>
        /// <param name="aBoard">The board where the player is moving</param>
        /// <param name="dir">Movement direction</param>
        public bool CanMoveInDirection(Board aBoard, Direction dir)
        {

        }

        /// <summary>
        /// Moves the player along a direction until it collides with a wall. 
        /// Player position is updated when the movement finishes.
        /// Returns whether the player has moved at least one position.
        /// </summary>
        /// <returns><c>true</c>, if the player has moved at least one position, <c>false</c> otherwise.</returns>
        /// <param name="aBoard">The board where the player is moving</param>
        /// <param name="dir">Movement direction</param>
        public bool Move(Board aBoard, Direction dir)
        {

        }

        /// <summary>
        /// Try to pick an item contained in player's position and store it in the bag.
        /// Return whether the player picks an item.
        /// </summary>
        /// <returns><c>true</c>, if there is an item in player's position <c>false</c> otherwise.</returns>
        /// <param name="aBoard">The board where the player is moving</param>
        public bool PickItem (Board aBoard)
        {

        }

        /// <summary>
        /// Returns the total value of the items stored in player's bag
        /// </summary>
        /// <returns>The sum of the values of the collected items</returns>
        /// <param name="aBoard">The board where the player is moving.</param>
        public int InventoryValue(Board aBoard)
        {

        }

        /// <summary>
        /// Checks if the player arrives at a goal position
        /// </summary>
        /// <returns><c>true</c>, if the player position is a goal <c>false</c> otherwise.</returns>
        /// <param name="aBoard">The board where the player is moving.</param>
        public bool GoalReached(Board aBoard)
        {

        }      
    }
}
