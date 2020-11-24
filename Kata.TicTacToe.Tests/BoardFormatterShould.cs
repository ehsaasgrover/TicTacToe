using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Kata.TicTacToe.Tests
{
    public class BoardFormatterShould
    {
        [Fact]
        public void FormatNineDotsGivenEmptyBoard()
        {
            // Arrange
            var board = new Board(3,3);
            // Act
            var actual = BoardFormatter.Format(board);
            // Assert
            const string expected = ". . . \n. . . \n. . . ";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormatXInTopLeftCorner()
        {
            // Arrange
            var board = new Board(3,3);
            var cell = board.Cells.FirstOrDefault(c => c.X == 0 && c.Y == 0);
            if (cell != null) cell.Piece = BoardPiece.X;
            // Act
            var actual = BoardFormatter.Format(board);
            // Assert
            const string expected = "X . . \n. . . \n. . . ";
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void FormatOInBottomRightCorner()
        {
            // Arrange
            var board = new Board(3,3);
            var cell = board.Cells.FirstOrDefault(c => c.X == 2 && c.Y == 2);
            if (cell != null) cell.Piece = BoardPiece.O;
            // Act
            var actual = BoardFormatter.Format(board);
            // Assert
            const string expected = ". . . \n. . . \n. . O ";
            Assert.Equal(expected, actual);
        }
        
        // [Fact]
        // public void CheckIfCellIsEmptyBeforeUserInput()
        // {
        //     // Arrange
        //     var board = new Board(3, 3);
        //     
        //     // Act
        //     UserInput.AddXUserInputToBoard(0,0);
        //     
        //     // Assert
        //     
        // }
        
        
    }

    
}