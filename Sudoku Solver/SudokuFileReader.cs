using System;
using System.IO;

namespace SudokuSolver {
    public class SudokuFileReader {
        public static string[] GetBoardLinesFromFile(string fileName) {
            try {
                return File.ReadAllLines(fileName.Trim());          
            }
            catch (Exception e) {
                throw new Exception("Something went wrong while reading the file: " + e.Message);
            }
        }       
    }
}