using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver.Helpers {
    public static class Utils {
        public static int joinNonZeroArrayValues(IEnumerable<int> array) {
            return array.Where(elem => elem != 0).Aggregate(0, (current, elem) => current * 10 + elem);
        }

        public static IEnumerable<int> splitIntegerIntoDigits(int a) {
            var result = new List<int>();
            int b;
            while (a != 0) {
                b = a % 10;
                result.Add(b);
                a = a / 10;
            }

            return result;
        }

        public static bool IsValidSingle(int cellDigit) {
            return cellDigit != 0 && cellDigit.ToString().Length == 1;
        }
    }
}