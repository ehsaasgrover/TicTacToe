using System;

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
            string userInput = Console.ReadLine();
           
        }
    }
}