using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const int MAXROW = 20, MAXCOL = 20;
            const int row = 3;
            const int col = 3;
            const int maxItems = 3;
            const string textMap = "00g0w0000";

            var theBoard = new Board(row, col, textMap, maxItems);
            theBoard.AddItem(2, 0, 10);
            theBoard.AddItem(2, 2, 5);
            var currPlayer = new Player();
            theBoard.PrintMap();

            var gameOver = false;
            while (!gameOver)
            {
                PrintPlayerPos();
                InputController();
                theBoard.PrintMap();
                
                if (currPlayer.PickItem(theBoard))
                {
                    Console.WriteLine("Player picked an item.");
                }
                
                PrintPlayerInfo();
                gameOver = currPlayer.GoalReached(theBoard);
            }
            
            Console.WriteLine("Player reached the goal");

            Console.ReadKey();


            // Manage the entry of the input
            void InputController()
            {
                Console.SetCursorPosition(21, 0);
                var key = Console.ReadLine();
                switch (key)
                {
                    case "a":
                        currPlayer.Move(theBoard, Direction.West);
                        break;
                    case "s":
                        currPlayer.Move(theBoard, Direction.South);
                        break;
                    case "w":
                        currPlayer.Move(theBoard, Direction.North);
                        break;
                    case "d":
                        currPlayer.Move(theBoard, Direction.East);
                        break;
                }
            }

            // Print in console current position of player in board and score
            void PrintPlayerInfo()
            {
                Console.SetCursorPosition(0, 3 + 1);
                Console.WriteLine($"Player: {currPlayer.Col.ToString()},{currPlayer.Row.ToString()}");
                Console.WriteLine($"Your points: {currPlayer.InventoryValue(theBoard).ToString()}");
            }

            // Print player position in board
            void PrintPlayerPos()
            {
                Console.SetCursorPosition(currPlayer.Col, currPlayer.Row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("*");
                Console.ResetColor();
            }
        }
    }
}