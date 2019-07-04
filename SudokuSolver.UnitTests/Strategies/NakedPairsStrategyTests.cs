using NUnit.Framework;
using SudokuSolver.Strategies;

namespace SudokuSolver.UnitTests.Strategies {
    public class NakedPairsStrategyTests {
        readonly ISudokuStrategy nakedPairsStrategy = new NakedPairsStrategy(new SudokuMapper());  

        [Test]
        public void ShouldEliminateNumbersInRowBasedOnNakedPair()
        {
            int[,] sudokuBoard = 
            {
                { 1, 2, 34, 5 , 34, 6, 7, 348, 9},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
            };

            var solvedSudokuBoard = nakedPairsStrategy.Solve(sudokuBoard);

            Assert.IsTrue(solvedSudokuBoard[0, 7] == 8);
        }

        [Test]
        public void ShouldEliminateNumbersInColBasedOnNakedPair()
        {
            int[,] sudokuBoard =
            {
                { 1, 0, 0, 0 , 0, 0, 0, 0, 0},
                { 24, 0, 0, 0, 0, 0, 0, 0, 0},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0},
                { 5, 0, 0, 0, 0, 0, 0, 0, 0},
                { 6, 0, 0, 0, 0, 0, 0, 0, 0},
                { 24, 0, 0, 0, 0, 0, 0, 0, 0},
                { 7, 0, 0, 0, 0, 0, 0, 0, 0},
                { 8, 0, 0, 0, 0, 0, 0, 0, 0},
                { 249, 0, 0, 0, 0, 0, 0, 0, 0},
            };

            var solvedSudokuBoard = nakedPairsStrategy.Solve(sudokuBoard);

            Assert.IsTrue(solvedSudokuBoard[8, 0] == 9);
        }

        [Test]
        public void ShouldEliminateNumbersInBlock1BasedOnNakedPair()
        {
            int[,] sudokuBoard =
            {
                { 1, 2, 3, 0 , 0, 0, 0, 0, 0},
                { 45, 6, 7, 0, 0, 0, 0, 0, 0},
                { 8, 45, 459, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
            };

            var solvedSudokuBoard = nakedPairsStrategy.Solve(sudokuBoard);

            Assert.IsTrue(solvedSudokuBoard[2, 2] == 9);
        }

        [Test]
        public void ShouldEliminateNumbersInBlock5BasedOnNakedPair()
        {
            int[,] sudokuBoard =
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 7, 8, 9, 0, 0, 0},
                { 0, 0, 0, 12, 3, 4, 0, 0, 0},
                { 0, 0, 0, 6, 12, 125, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
            };

            var solvedSudokuBoard = nakedPairsStrategy.Solve(sudokuBoard);

            Assert.IsTrue(solvedSudokuBoard[5, 5] == 5);
        }

        [Test]
        public void ShouldEliminateNumbersInBlock9BasedOnNakedPair()
        {
            int[,] sudokuBoard =
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0 ,0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 1, 2, 3},
                { 0, 0, 0, 0, 0, 0, 4, 56, 56},
                { 0, 0, 0, 0, 0, 0, 567, 8, 9},
            };

            var solvedSudokuBoard = nakedPairsStrategy.Solve(sudokuBoard);

            Assert.IsTrue(solvedSudokuBoard[8, 6] == 7);
        }
    }
}