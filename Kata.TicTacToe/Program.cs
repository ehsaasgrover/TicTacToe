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
            Console.Write("Player 1 enter a coord x,y to place your X or enter 'q' to give up: ");
            string[] userInput = Console.ReadLine().Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
            int x = int.Parse(userInput[0]);
            int y = int.Parse(userInput[1]);
            Console.WriteLine(x);
            Console.WriteLine(y);
            

        }
    }
}