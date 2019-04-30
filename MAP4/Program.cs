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
            Random rnd = new Random();
            const int MAXROW = 20, MAXCOL = 20;
            int row = 3, col = 3,maxItems = 3;
            string textMap = "00g0w0000";

            //GameStart();
            Board theBoard = new Board(row, col, textMap, maxItems);
            theBoard.AddItem(2,2,3);
            Player currPlayer = new Player();
            theBoard.PrintMap();


            bool gameOver = false;
            while (!gameOver)
            {
                InputController();
                currPlayer.PickItem(theBoard);
                theBoard.PrintMap();
                PrintPlayerInfo();
                PrintPlayerPos();
                gameOver = currPlayer.GoalReached(theBoard);

            }

            Console.ReadKey();



            void InputController()
            {
                Console.SetCursorPosition(21,5);
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

            void PrintPlayerInfo()
            {
                Console.SetCursorPosition(0,3+1);
                Console.WriteLine("Player: "+currPlayer._col+","+currPlayer._row);
                Console.WriteLine("Your points :"+currPlayer.InventoryValue(theBoard));

            }

            void GameStart()
            {
                bool startGame = false;

                while(!startGame)
                {
                    try
                    {
                        Console.WriteLine("Enter the length of the board (MAX " + MAXROW + ")");
                        int currRow = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the width of the board (MAX " + MAXCOL + ")");
                        int currCol = int.Parse(Console.ReadLine());
                        if (currRow <= MAXROW && currCol <= MAXCOL)
                        {
                            row = currRow;
                            col = currCol;
                            startGame = true;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                for (int i = 0; i< row * col;i++ )
                {
                    textMap += "0"; 
                }

            }

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
