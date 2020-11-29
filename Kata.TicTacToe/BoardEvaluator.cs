using System;
using System.Linq;
using System.Net;

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

            // return !_board.Cells.Any(c => c.Piece == BoardPiece.Empty);

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
        
        public bool HasWinCondition()
        {
            return HasHorizontalWinCondition() || HasDiagonalWinCondition() || HasVerticalWinCondition();
        }
        
        private bool HasHorizontalWinCondition()
        {
            for (var y = 0; y < _board.Height; y++)
            {
                var comparisonPiece = _board.GetCell(0, y).Piece;
                if (comparisonPiece == BoardPiece.Empty) continue;
                var cellsInCurrentHorizontal = _board.Cells.Where(c => c.Y == y);
                var currentHorizontalHasWinCondition = cellsInCurrentHorizontal.All(c => c.Piece == comparisonPiece);
                if (currentHorizontalHasWinCondition) return true;
            }
            return false;
        }

        private bool HasDiagonalWinCondition()
        {
            return HasDiagonalWinConditionBottomLeftToTopRight() || HasDiagonalWinConditionTopLeftToBottomRight();
        }
        
        
        private bool HasDiagonalWinConditionTopLeftToBottomRight()
        {
            var comparisonPiece = _board.GetCell(0,0).Piece;
            if (comparisonPiece == BoardPiece.Empty) return false;
            var cellsInDiagonal = _board.Cells.Where(c => c.Y == c.X);
            var diagonalHasWinCondition = cellsInDiagonal.All(c => c.Piece == comparisonPiece);
            return diagonalHasWinCondition;

            // if ((_board.GetCell(0, 0).Piece == BoardPiece.X) && (_board.GetCell(1, 1).Piece == BoardPiece.X) &&
            //     (_board.GetCell(2, 2).Piece == BoardPiece.X))
            // {
            //     return true;
            // }
            //
            // return false;
        }

        private bool HasDiagonalWinConditionBottomLeftToTopRight()
        {
            var comparisonPiece = _board.GetCell(0,_board.Height-1).Piece;
            if (comparisonPiece == BoardPiece.Empty) return false;
            var cellsInDiagonal = _board.Cells.Where(c => c.Y == _board.Width - 1 - c.X);
            var diagonalHasWinCondition = cellsInDiagonal.All(c => c.Piece == comparisonPiece);
            return diagonalHasWinCondition;
            // for (var x = 0; x < _board.Width; x++)
            // {
            //     = _board.GetCell(x, (_board.Width - 1) - x).Piece;
            // }
            // if (diagonalCells == piece)
            // {
            //     return true;
            // }
            // return false;
        }

        private bool HasVerticalWinCondition()
        {
            for (var x = 0; x < _board.Width; x++)
            {
                var comparisonPiece = _board.GetCell(x, 0).Piece;
                if (comparisonPiece == BoardPiece.Empty) continue;
                var cellsInCurrentVertical = _board.Cells.Where(c => c.X == x);
                var currentVerticalHasWinCondition = cellsInCurrentVertical.All(c => c.Piece == comparisonPiece);
                if (currentVerticalHasWinCondition) return true;    
            }
            return false;
            
            // for (var x = 0; x < _board.Width; x++)
            // {
            //     var comparisonPiece = _board.GetCell(x, 0).Piece;
            // if (comparisonPiece == BoardPiece.Empty) continue;
            //     var verticalIsWinCondition = true;
            //     for (var y = 1; y < _board.Height; y++)
            //     {
            //         if (comparisonPiece != _board.GetCell(x, y).Piece)
            //         {
            //             verticalIsWinCondition = false;
            //             break;
            //         }
            //     }
            //     if (verticalIsWinCondition) return true;
            // }
            // return false;
        }
        
    }
}