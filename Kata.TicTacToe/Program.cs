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
            var board = new Board(3,3);
            var evaluator = new BoardEvaluator(board);
            var input = new InputValidation();
            Console.WriteLine(BoardFormatter.Format(board));
            Console.WriteLine(" ");
            var isPlayerOnesTurn = true;
            while (true)
            {
                var player = isPlayerOnesTurn ? "1" : "2";
                var piece = isPlayerOnesTurn ? "X" : "O";
                Console.Write($"Player {player} enter a coord x,y to place your {piece} or enter 'q' to give up: ");
                var userInput = Console.ReadLine();
                if (userInput != null && userInput.Equals("q"))
                {
                    Console.Write("Player has given up");
                    Environment.Exit(0);
                }
                var isValidInput = input.IsValidInput(userInput, board);
                int x;
                int y;
                if (!isValidInput)
                {
                    Console.WriteLine("Please enter a valid input!");
                }
                else {
                    var stringCoords = userInput.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                    x = int.Parse(stringCoords[0]);
                    y = int.Parse(stringCoords[1]);
                    var cell = board.GetCell(x,y);
                    if (cell != null) cell.Piece = isPlayerOnesTurn ? BoardPiece.X : BoardPiece.O;
                    Console.WriteLine(BoardFormatter.Format(board));
                    Console.WriteLine("");
                    isPlayerOnesTurn = !isPlayerOnesTurn;
                    if (evaluator.HasWinCondition())
                    {
                        Console.WriteLine("We have a winner!!");
                        Environment.Exit(0);
                    }
                    else if (evaluator.IsFull())
                    {
                        Console.WriteLine("Board is full. Game over");
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}