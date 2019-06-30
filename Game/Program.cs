using System;

namespace Game
{
    internal static class Program
    {
        private static int MaxRows { get; } = 3;
        private static int MaxCols { get; } = 3;
        private static int MaxItems { get; } = 3;
        private static string TextMap { get; } = "00g0w0000";

        private static void Main()
        {
            var board = new Board(MaxRows, MaxCols, TextMap, MaxItems);
            board.AddItem(2, 0, 10);
            board.AddItem(2, 2, 5);
            var player = new Player();
            board.PrintMap();

            var gameOver = false;
            while (!gameOver)
            {
                PrintPlayerPos(player);
                InputController(board, player);
                board.PrintMap();

                if (player.PickItem(board))
                {
                    Console.WriteLine("Player picked an item.");
                }

                PrintPlayerInfo(board, player);
                gameOver = player.GoalReached(board);
            }

            Console.WriteLine("Player reached the goal");
            Console.ReadKey();
        }

        // Manage the entry of the input
        private static void InputController(Board board, Player player)
        {
            Console.SetCursorPosition(21, 0);
            var key = Console.ReadLine();

            switch (key)
            {
                case "a":
                    player.Move(board, Direction.West);
                    break;
                case "s":
                    player.Move(board, Direction.South);
                    break;
                case "w":
                    player.Move(board, Direction.North);
                    break;
                case "d":
                    player.Move(board, Direction.East);
                    break;
            }
        }

        // Print in console current position of player in board and score
        private static void PrintPlayerInfo(Board board, Player player)
        {
            Console.SetCursorPosition(0, 3 + 1);
            Console.WriteLine($"Player: {player.Col.ToString()},{player.Row.ToString()}");
            Console.WriteLine($"Your points: {player.InventoryValue(board).ToString()}");
        }

        // Print player position in board
        private static void PrintPlayerPos(Player player)
        {
            Console.SetCursorPosition(player.Col, player.Row);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("*");
            Console.ResetColor();
        }
    }
}