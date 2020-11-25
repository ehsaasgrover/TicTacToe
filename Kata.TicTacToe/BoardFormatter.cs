using System.Linq;

namespace Kata.TicTacToe
{
    public static class BoardFormatter
    {
        public static string Format(Board board)
        {
            var topLeft = FormatCell(board,0, 0);
            var topMiddle = FormatCell(board, 1, 0);
            var topRight = FormatCell(board, 2, 0);
            var middleLeft = FormatCell(board, 0, 1);
            var middle = FormatCell(board, 1, 1);
            var middleRight = FormatCell(board, 2, 1);
            var bottomLeft = FormatCell(board, 0, 2);
            var bottomMiddle = FormatCell(board, 1, 2);
            var bottomRight = FormatCell(board, 2, 2);
            var output = $"{topLeft} {topMiddle} {topRight} \n{middleLeft} {middle} {middleRight} \n{bottomLeft} {bottomMiddle} {bottomRight} ";

            return output;
            throw new System.NotImplementedException();
        }

        private static string FormatCell(Board board, int x, int y)
        {
            var cell = board.GetCell(x,y);
            if (cell != null && cell.Piece == BoardPiece.X)
            {
                return "X";
            }
            if (cell != null && cell.Piece == BoardPiece.O)
            {
                return "O";
            }
            return ".";
        }
    }
}