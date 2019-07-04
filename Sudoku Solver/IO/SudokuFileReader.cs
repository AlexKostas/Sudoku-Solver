using System;
using System.IO;
using SudokuSolver.Helpers;

namespace SudokuSolver.IO {
    public static class SudokuFileReader {
        public static int[,] ReadBoardFromFile(string fileName) {
            return BoardCreator.GetBoardFromBoardlines(GetBoardLinesFromFile(fileName));
        }
        
        static string[] GetBoardLinesFromFile(string fileName) {
            try {
                return File.ReadAllLines(fileName.Trim());          
            }
            catch (Exception e) {
                throw new Exception("Something went wrong while reading the file: " + e.Message);
            }
        }       
    }
}