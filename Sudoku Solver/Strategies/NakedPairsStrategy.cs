using System;

namespace SudokuSolver.Strategies {
    public class NakedPairsStrategy : ISudokuStrategy {
        readonly SudokuMapper sudokuMapper;

        public NakedPairsStrategy(SudokuMapper sudokuMapper) {
            this.sudokuMapper = sudokuMapper;
        }

        public int[,] Solve(int[,] board) {
            for (int row = 0; row < board.GetLength(0); row++) {
                for (int col = 0; col < board.GetLength(1); col++) {
                    EliminateNakedPairFromOthersInRow(board, row, col);
                    EliminateNakedPairFromOthersInCol(board, row, col);
                    EliminateNakedPairFromOthersInBlock(board, row, col);
                }
            }

            return board;
        }

        void EliminateNakedPairFromOthersInRow(int[,] board, int givenRow, int givenCol) {
            if (!HasNakedPairInRow(board, givenRow, givenCol)) return;

            for (int col = 0; col < board.GetLength(0); col++)
                if (board[givenRow, col] != board[givenRow, givenCol] && board[givenRow, col].ToString().Length > 1)
                    EliminateNakedPair(board, board[givenRow, givenCol], givenRow, col);
        }

        void EliminateNakedPairFromOthersInCol(int[,] board, int givenRow, int givenCol) {
            if (!HasNakedPairInCol(board, givenRow, givenCol)) return;

            for (int row = 0; row < board.GetLength(0); row++)
                if (board[row, givenCol] != board[givenRow, givenCol] && board[row, givenCol].ToString().Length > 1) {
                    EliminateNakedPair(board, board[givenRow, givenCol], row, givenCol);
                }
        }

        void EliminateNakedPairFromOthersInBlock(int[,] board, int givenRow, int givenCol) {
            if (!HasNakedPairInBlock(board, givenRow, givenCol)) return;

            var sudokuMap = sudokuMapper.Find(givenRow, givenCol);

            for (int row = sudokuMap.StartRow; row <= sudokuMap.StartRow + 2; row++) {
                for (int col = sudokuMap.StartColumn; col <= sudokuMap.StartColumn + 2; col++)
                    if (board[row, col].ToString().Length > 1 && board[row, col] != board[givenRow, givenCol])
                        EliminateNakedPair(board, board[givenRow, givenCol], row, col);
            }
        }

        bool HasNakedPairInRow(int[,] board, int givenRow, int givenCol) {
            for (int col = 0; col < board.GetLength(0); col++)
                if (givenCol != col && IsNakedPair(board[givenRow, col], board[givenRow, givenCol]))
                    return true;
            return false;
        }

        bool HasNakedPairInCol(int[,] board, int givenRow, int givenCol) {
            for (int row = 0; row < board.GetLength(0); row++)
                if (givenRow != row && IsNakedPair(board[row, givenCol], board[givenRow, givenCol]))
                    return true;
            return false;
        }

        bool HasNakedPairInBlock(int[,] board, int givenRow, int givenCol) {
            for (int row = 0; row < board.GetLength(0); row++) {
                for (int col = 0; col < board.GetLength(1); col++) {
                    var elementSame = givenRow == row && givenCol == col;
                    var elementInSameBlock = sudokuMapper.Find(givenRow, givenCol).StartRow
                                             == sudokuMapper.Find(row, col).StartRow &&
                                             sudokuMapper.Find(givenRow, givenCol).StartColumn
                                             == sudokuMapper.Find(row, col).StartColumn;
                    if (!elementSame && elementInSameBlock && IsNakedPair(board[givenRow, givenCol], board[row, col]))
                        return true;
                }
            }

            return false;
        }

        void EliminateNakedPair(int[,] board, int valuesToEliminate, int eliminateFromRow, int eliminateFromCol) {
            var valuesToEliminateArray = valuesToEliminate.ToString().ToCharArray();
            foreach (var valueToEliminate in valuesToEliminateArray)
                board[eliminateFromRow, eliminateFromCol] = Convert.ToInt32(board[eliminateFromRow, eliminateFromCol]
                    .ToString().Replace(valueToEliminate.ToString(), string.Empty));
        }

        bool IsNakedPair(int firstPair, int secondPair) {
            return firstPair.ToString().Length == 2 && firstPair == secondPair;
        }
    }
}