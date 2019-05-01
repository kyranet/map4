using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {

            const int MAXROW = 20, MAXCOL = 20;
            int row = 3, col = 3,maxItems = 3;
            string textMap = "00g0w0000";

            Board theBoard = new Board(row, col, textMap, maxItems);
            theBoard.AddItem(2, 0, 10);
            theBoard.AddItem(2, 2, 5);
            Player currPlayer = new Player();
            theBoard.PrintMap();


            bool gameOver = false;
            while (!gameOver)
            {
                PrintPlayerPos();
                InputController();
                currPlayer.PickItem(theBoard);
                theBoard.PrintMap();
                PrintPlayerInfo();
                gameOver = currPlayer.GoalReached(theBoard);

            }

            Console.ReadKey();


            ///Manage the entry of the input
            void InputController()
            {
                Console.SetCursorPosition(21,0);
                string key = Console.ReadLine();
                switch(key)
                {
                    case "a":
                        currPlayer.Move(theBoard,Direction.West);
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
                    default:
                        break;
                }
            }

            ///Print in console current position of player in board and score
            void PrintPlayerInfo()
            {
                Console.SetCursorPosition(0,3+1);
                Console.WriteLine("Player: "+currPlayer._col+","+currPlayer._row);
                Console.WriteLine("Your points :"+currPlayer.InventoryValue(theBoard));
            }

            ///Print player position in board
            void PrintPlayerPos()
            {
                Console.SetCursorPosition(currPlayer._col, currPlayer._row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("*");
                Console.ResetColor();

            }
        }
    }
}
