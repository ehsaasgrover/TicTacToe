using Xunit;

namespace Kata.TicTacToe.Tests
{
    public class BoardShould
    {
        [Fact]
        public void InitializeWithEmptyCells()
        {
            // Arrange 
            var board = new Board(3, 3);
            
            // Assert
            Assert.Equal(9, board.Cells.Count);
            Assert.All(board.Cells, cell => Assert.Equal(BoardPiece.Empty, cell.Piece));
        }
        
        
    }
    

    
}