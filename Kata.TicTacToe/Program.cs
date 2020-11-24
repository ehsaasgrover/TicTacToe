using System;
using System.Linq;

namespace Kata.TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Here's my current board: ");
            Console.WriteLine(" ");
            Board board = new Board(3,3);
            Console.Write(BoardFormatter.Format(board));
            Console.WriteLine(" ");
            var IsPlayerOnesTurn = true;
            while (true)
            {
                var player = IsPlayerOnesTurn ? "1" : "2";
                var piece = IsPlayerOnesTurn ? "X" : "O";
                Console.Write($"Player {player} enter a coord x,y to place your {piece} or enter 'q' to give up: ");
                var userInput = Console.ReadLine();
                
                if (userInput != null && userInput.Equals("q"))
                {
                    Console.Write("Player has given up");
                    Environment.Exit(0);
                }

                var isValidInput = IsValidInput(userInput, board);
                var cell = board.Cells.FirstOrDefault(c => c.X == x && c.Y == y);
                if (cell != null) cell.Piece = IsPlayerOnesTurn ? BoardPiece.X : BoardPiece.O;
                Console.Write(BoardFormatter.Format(board));
                IsPlayerOnesTurn = !IsPlayerOnesTurn;
            }
        }

        private static bool IsValidInput(string userInput, Board board)
        {
            if (userInput == null) return false;
            var stringCoords = userInput.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
            if (stringCoords.Length != 2) return false;
            var isValidX = int.TryParse(stringCoords[0], out var x);
            if (!isValidX) return false;
            if (x < 0 || x > board.Width - 1) return false;
            var isValidY = int.TryParse(stringCoords[1], out var y);
            if (!isValidY) return false;
            if (y < 0 || y > board.Height - 1) return false;
            var cell = board.Cells.FirstOrDefault(c => c.X == x && c.Y == y);
            if (cell != null && cell.Piece != BoardPiece.Empty) return false;
            return true;
        }
    }
}