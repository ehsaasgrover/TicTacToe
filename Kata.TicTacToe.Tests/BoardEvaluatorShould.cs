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
            //Act
            var actual = _evaluator.IsFull();
            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ReturnWinWhenThreeSameCellPiecesAreHorizontal()
        {
            // Arrange
            PopulateBoardWithThreeXsInARow();
            // Act
            var actual = _evaluator.HasWinCondition();
            // Assert
            Assert.True(actual);
        }
        
        [Fact]
        public void ReturnWinWhenThreeSameCellPiecesAreVertical()
        {
            // Arrange
            _board.GetCell(1, 0).Piece = BoardPiece.X;
            _board.GetCell(1, 1).Piece = BoardPiece.X;
            _board.GetCell(1, 2).Piece = BoardPiece.X;
            // Act
            var actual = _evaluator.HasWinCondition();
            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void ReturnWinWhenCellsOfSamePieceAreDiagonal()
        {
            // Arrange
            PopulateBoardWithThreeXsDiagonally();
            // Act
            var actual = _evaluator.HasWinCondition();
            // Assert
            Assert.True(actual);
        }

        private void PopulateBoardWithThreeXsInARow()
        {
            var y = _random.Next(_board.Height);
            var piece = _random.Next(2) == 0 ? BoardPiece.X : BoardPiece.O;
            for (var x = 0; x < _board.Width; x++)
            {
                _board.GetCell(x,y).Piece = piece;
            }
        }

        private void PopulateBoardWithThreeXsDiagonally()
        {
            var piece = _random.Next(2) == 0 ? BoardPiece.X : BoardPiece.O;
            for (var x = 0; x < _board.Width; x++)
            {
                _board.GetCell(x, x).Piece = piece;
            }
            
            // Need to do negative diagonal
            // _board.GetCell(2, 0).Piece = BoardPiece.X;
            // _board.GetCell(1, 1).Piece = BoardPiece.X;
            // _board.GetCell(0, 2).Piece = BoardPiece.X;
        }
        
        private void RandomlyPopulateBoardWithXsAndOs()
        {
            // foreach (var c in _board.Cells)
            // {
            //     var rand = new Random().Next(0,1);
            //     c.Piece = rand == 0 ? BoardPiece.X : BoardPiece.O;
            // }
            
            // for (var i = 0; i < _board.Cells.Count; i++)
            // {
            //     var rand = new Random().Next(0,1);
            //     _board.Cells[i].Piece = rand == 0 ? BoardPiece.X : BoardPiece.O;  
            // }
            _board.Cells.ForEach(c => c.Piece = _random.Next(2) == 0 ? BoardPiece.X : BoardPiece.O);    
        }
    }
}