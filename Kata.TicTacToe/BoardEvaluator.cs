using System.Linq;

namespace Kata.TicTacToe
{
    public class BoardEvaluator
    {
        private readonly Board _board;
        public BoardEvaluator(Board board)
        {
            _board = board;
        }

        public bool IsFull()
        {
            // for (var i = 0; i < _board.Cells.Count; i++)
            // {
            //     if (_board.Cells[i].Piece == BoardPiece.Empty)
            //     {
            //         return false;
            //     }
            // }
            // return true;
            
            //return !_board.Cells.Any(c => c.Piece == BoardPiece.Empty);

            return _board.Cells.All(c => c.Piece != BoardPiece.Empty);

            foreach (var c in _board.Cells)
            {
                if (c.Piece == BoardPiece.Empty)
                {
                    return false;
                } 
            }
            return true;
        }
    }
}