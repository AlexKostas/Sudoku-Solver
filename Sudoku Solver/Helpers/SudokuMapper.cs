using SudokuSolver.Data;

namespace SudokuSolver.Helpers {
    public class SudokuMapper {
        public SudokuMap Find(int row, int col) {
            return new SudokuMap {StartRow = (row / 3) * 3, StartColumn = (col / 3) * 3};
        }
    }
}