using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Helpers;

namespace SudokuSolver.Strategies {
    public class SudokuSolverEngine {
        readonly BoardStateManager boardStateManager;
        readonly SudokuMapper sudokuMapper;

        public SudokuSolverEngine(BoardStateManager boardStateManager, SudokuMapper sudokuMapper) {
            this.boardStateManager = boardStateManager;
            this.sudokuMapper = sudokuMapper;
        }

        public bool Solve(int[,] sudokuBoard) {
            var strategies = new List<ISudokuStrategy>() {
                new SimpleMarkupStrategy(sudokuMapper),
                new NakedPairsStrategy(sudokuMapper)
            };

            var currentState = boardStateManager.GenerateState(sudokuBoard);
            var nextState = boardStateManager.GenerateState(strategies.First().Solve(sudokuBoard));

            while (!boardStateManager.IsSolved(sudokuBoard) && currentState != nextState) {
                currentState = nextState;
                foreach (var strategy in strategies) 
                    nextState = boardStateManager.GenerateState(strategy.Solve(sudokuBoard));
            }

            return boardStateManager.IsSolved(sudokuBoard);
        }
    }
}