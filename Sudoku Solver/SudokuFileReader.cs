using System;
using System.IO;

namespace SudokuSolver {
    public class SudokuFileReader {
        static int[,] readBoardFromFile(string fileName) {
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