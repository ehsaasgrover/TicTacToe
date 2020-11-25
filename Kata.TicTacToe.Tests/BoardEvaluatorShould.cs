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