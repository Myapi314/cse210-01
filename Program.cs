using System;

namespace tictactoe
{
    class Program
    {
        static void Main(string[] args)
        {
            string player = NextPlayer("");
            string[] board = CreateBoard();

            while (!IsFinished(board) && !HasWinner(board))
            {
                DisplayBoard(board);
                MakeMove(player, board);
                player = NextPlayer(player);
            }

            DisplayBoard(board);

            // Added declaring winner/draw depending on how the game ends.
            if (HasWinner(board)) {
                Console.WriteLine($"\n{NextPlayer(player)} wins!");
            }
            else if (IsFinished(board)) {
                Console.WriteLine("\nDraw :P");
            }
            Console.WriteLine("\nGood game. Thanks for playing.");
        }

        static string[] CreateBoard()
        {
            string[] board = new string[9];
            for (int i = 0; i < 9; i++)
            {
                board[i] = (i + 1).ToString();
            }
            return board;
        }

        static void DisplayBoard(string[] board)
        {
            Console.WriteLine();
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }

        static bool HasWinner(string[] board)
        {
            // Adjusted HasWinner to be true when either player gets 3 in a row.
            return ((board[0] == board[1] && board[0] == board[2]) ||
                    (board[3] == board[4] && board[3] == board[5]) ||
                    (board[6] == board[7] && board[6] == board[8]) ||
                    (board[0] == board[3] && board[0] == board[6]) ||
                    (board[1] == board[4] && board[1] == board[7]) ||
                    (board[2] == board[5] && board[2] == board[8]) ||
                    (board[0] == board[4] && board[0] == board[8]) ||
                    (board[2] == board[4] && board[2] == board[6]));
        }

        static bool IsFinished(string[] board)
        {
            bool result = true;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] != "x" && board[i] != "o")
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        static void MakeMove(string player, string[] board)
        {
            Console.Write($"\n{player}'s turn to choose a square (1-9): ");
            int square = Convert.ToInt32(Console.ReadLine());
            while (board[square -1] == "x" || board[square - 1] == "o")
            {

                // Validate the user's input and ensure that the spot hasn't already been taken.
                Console.WriteLine($"{board[square - 1]} is already in that spot! Try again.");
                Console.Write($"\n{player}'s turn to choose a square (1-9): ");
                square = Convert.ToInt32(Console.ReadLine());
            }
                
            board[square - 1] = player;
        }

        static string NextPlayer(string current)
        {
            string player = "o";
            if (current == "" || current == "o")
            {
                player = "x";
            }
            return player;
        }
    }
}