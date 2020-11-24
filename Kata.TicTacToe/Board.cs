using System.Collections.Generic;

namespace Kata.TicTacToe
{
    public class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Cell> Cells { get; set; } = new List<Cell>();

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            InitializeCells();
        }

        private void InitializeCells()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var cell = new Cell {X = x, Y = y, Piece = BoardPiece.Empty};
                    Cells.Add(cell);
                }
            }
        }
    }
}