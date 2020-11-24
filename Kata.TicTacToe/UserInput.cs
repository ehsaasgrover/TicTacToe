using System.Threading;

namespace Kata.TicTacToe
{
    public class UserInput
    {
        
        public static void AddXUserInputToBoard(int x, int y)
        {
            var cell = new Cell {X = x, Y = y, Piece = BoardPiece.X};
            
        }
    }
    
}