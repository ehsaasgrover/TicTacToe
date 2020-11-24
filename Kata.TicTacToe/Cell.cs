namespace Kata.TicTacToe
{
    public class Cell
    {
        public BoardPiece Piece { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
    public enum BoardPiece
    {
        X,
        O,
        Empty
    }
}