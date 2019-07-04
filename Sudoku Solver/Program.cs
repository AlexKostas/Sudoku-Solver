using System;
using SudokuSolver.Strategies;

namespace SudokuSolver {
    internal static class Program {
        public static void Main() {
            try {
                var sudokuMapper = new SudokuMapper();
                var boardStateManager = new BoardStateManager();
                var solverEngine = new SudokuSolverEngine(boardStateManager, sudokuMapper);
                var boardDisplayer = new BoardDisplayer();
                
                Console.WriteLine("Please enter the filename containing the sudoku puzzle");
                var fileName = Console.ReadLine();
                var sudokuBoard = SudokuFileReader.ReadBoardFromFile(fileName);
                boardDisplayer.Display("Initial State", sudokuBoard);
                bool isSolved = solverEngine.Solve(sudokuBoard);
                boardDisplayer.Display("Final State", sudokuBoard);
                Console.WriteLine(isSolved ? "Sudoku puzzle was solved successfully" : "Current algorithms can " +
                                                                                       "not solve this puzzle");
            }
            catch (Exception e) {
                Console.WriteLine("An error occured trying to solve sudoku puzzle : {0}", e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}