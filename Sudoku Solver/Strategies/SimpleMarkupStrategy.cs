using System;
using System.Linq;

namespace SudokuSolver.Strategies {
    public class SimpleMarkupStrategy : ISudokuStrategy {
        readonly SudokuMapper sudokuMapper;

        public SimpleMarkupStrategy(SudokuMapper sudokuMapper) {
            this.sudokuMapper = sudokuMapper;
        }
        
        public int[,] Solve(int[,] board) {
            for (int row = 0; row < board.GetLength(0); row++) 
                for (int col = 0; col < board.GetLength(1); col++) {
                    if (board[row, col] == 0 || board[row, col].ToString().Length > 1) {
                        var possibilitiesInRowAndCol = GetPossibilitiesInRowAndCol(board, row, col);
                        var possibilitiesInBlock = GetPossibilitiesInBlock(board, row, col);
                        board[row, col] = GetPossibilitiesIntersection(possibilitiesInRowAndCol, possibilitiesInBlock);
                    }
                }
            return board;
        }

        int GetPossibilitiesInRowAndCol(int[,] board, int givenRow, int givenCol) {
            int[] possibilities = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            for (int col = 0; col < 9; col++) 
                if (IsValidSingle(board[givenRow, col])) possibilities[board[givenRow, col] - 1] = 0;
            for (int row = 0; row < 9; row++) 
                if (IsValidSingle(board[row, givenCol])) possibilities[board[row, givenCol] - 1] = 0;

            return Convert.ToInt32(string.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }    

        int GetPossibilitiesInBlock(int[,] board, int givenRow, int givenCol) {
            int[] possibilities = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var sudokuMap = sudokuMapper.Find(givenRow, givenCol);

            for (int row = sudokuMap.StartRow; row <= sudokuMap.StartRow + 2; row++) {
                for (int col = sudokuMap.StartColumn; col <= sudokuMap.StartColumn + 2; col++) {
                    if (IsValidSingle(board[row, col])) possibilities[board[row, col] - 1] = 0;
                }
            }
            
            return Convert.ToInt32(string.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }

        int GetPossibilitiesIntersection(int possibilitiesInRowAndCol, int possibilitiesInBlock) {
            var possibilitiesInRowAndColCharArray = possibilitiesInRowAndCol.ToString().ToCharArray();
            var possibilitiesInBlockCharArray = possibilitiesInBlock.ToString().ToCharArray();
            var possibilitiesIntersection = possibilitiesInBlockCharArray.Intersect(possibilitiesInRowAndColCharArray);
            return Convert.ToInt32(string.Join(string.Empty, possibilitiesIntersection));
        }
        
        bool IsValidSingle(int cellDigit) {
            return cellDigit != 0 && cellDigit.ToString().Length == 1;
        }
    }
}