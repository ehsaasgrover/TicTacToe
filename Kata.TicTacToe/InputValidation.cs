using System;

namespace Kata.TicTacToe
{
    public class InputValidation
    {
        public bool IsValidInput(string userInput, Board board)
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
            var cell = board.GetCell(x, y);
            if (cell != null && cell.Piece != BoardPiece.Empty) return false;
            return true;
        }
    }
}