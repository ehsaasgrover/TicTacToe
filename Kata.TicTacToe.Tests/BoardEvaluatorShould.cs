using System;
using Xunit;

namespace Kata.TicTacToe.Tests
{
    public class BoardEvaluatorShould
    {
        private readonly Board _board;
        private readonly BoardEvaluator _evaluator;
        private readonly Random _random;

        public BoardEvaluatorShould()
        {
            _random = new Random();
            _board = new Board(3,3);
            _evaluator = new BoardEvaluator(_board);
        }
        
        [Fact]
        public void ReturnBoardFullWhenAllCellsArePopulated()
        {
            // Arrange
            RandomlyPopulateBoardWithXsAndOs();
            // Act
            var actual = _evaluator.IsFull();
            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void ReturnBoardNotFullWhenAllCellsAreEmpty()
        {
            // Arrange
            // Act
            var actual = _evaluator.IsFull();
            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void ReturnBoardNotFullWhenCellsArePartiallyFull()
        {
            // Arrange
            var index = _random.Next(_board.Cells.Count);
            _board.Cells[index].Piece = _random.Next(2) == 0 ? BoardPiece.X : BoardPiece.O; 
            // Act
            var actual = _evaluator.IsFull();
            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void ReturnWinWhenThreeSameCellPiecesAreHorizontal()
        {
            // Arrange
            PopulateBoardWithAllSamePiecesInARow();
            // Act
            var actual = _evaluator.HasWinCondition();
            // Assert
            Assert.True(actual);
        }
        
        [Fact]
        public void ReturnWinWhenThreeSameCellPiecesAreVertical()
        {
            // Arrange
            PopulateBoardWithAllSamePiecesInAColumn();
            // Act
            var actual = _evaluator.HasWinCondition();
            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void ReturnWinWhenCellsOfSamePieceAreNegativeDiagonal()
        {
            // Arrange
            PopulateBoardWithSameCellsInNegativeGradient();
            // Act
            var actual = _evaluator.HasWinCondition();
            // Assert
            Assert.True(actual);
        } 
        
        [Fact]
        public void ReturnWinWhenCellsOfSamePieceArePositiveDiagonal()
        {
            // Arrange
            PopulateBoardWithSameCellsInPositiveGradient();
            // Act
            var actual = _evaluator.HasWinCondition();
            // Assert
            Assert.True(actual);
        }    

        private void PopulateBoardWithAllSamePiecesInARow()
        {
            var y = _random.Next(_board.Height);
            var piece = _random.Next(2) == 0 ? BoardPiece.X : BoardPiece.O;
            for (var x = 0; x < _board.Width; x++)
            {
                _board.GetCell(x,y).Piece = piece;
            }
        }
            
        private void PopulateBoardWithAllSamePiecesInAColumn()
        {
            var x = _random.Next(_board.Width);
            var piece = _random.Next(2) == 0 ? BoardPiece.X : BoardPiece.O;
            for (var y = 0; y < _board.Height; y++)
            {
                _board.GetCell(x,y).Piece = piece;
            }
        }

        private void PopulateBoardWithSameCellsInPositiveGradient()
        {
            var piece = _random.Next(2) == 0 ? BoardPiece.X : BoardPiece.O;
            for (var x = 0; x < _board.Width; x++)
            {
                _board.GetCell(x, (_board.Width - 1) - x).Piece = piece;
            }
        }

        private void PopulateBoardWithSameCellsInNegativeGradient()
        {
            var piece = _random.Next(2) == 0 ? BoardPiece.X : BoardPiece.O;
            for (var x = 0; x < _board.Width; x++)
            {
                _board.GetCell(x, x).Piece = piece;
            }
        }
        
        private void RandomlyPopulateBoardWithXsAndOs()
        {
            _board.Cells.ForEach(c => c.Piece = _random.Next(2) == 0 ? BoardPiece.X : BoardPiece.O);    
        }
    }
}