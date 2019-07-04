using System;
using System.Linq;

namespace SudokuSolver.Helpers {
    public static class BoardCreator {
        public static int[,] GetBoardFromBoardlines(string[] boardLines) {
            try {
                return CreateBoard(boardLines);
            }
            catch (Exception e) {
                throw new Exception("Something went wrong while creating the board: " + e.Message);
            }

        }

        static int[,] CreateBoard(string[] boardLines) {
            var board = new int[9, 9];
            for (int row = 0; row < boardLines.Length; row++) {
                var boardLineElements = getFormattedLineElements(boardLines[row]);
                for (int col = 0; col < boardLineElements.Length; col++)
                    board[row, col] = convertStringElementToBoardNumber(boardLineElements[col]);
            }

            return board;
        }
        
        /// <summary>
        /// Splits a line to individual string elements to match the required format for this project
        /// </summary>
        /// <param name="line">The line to perform the operation on</param>
        /// <returns>List of formatted line elements</returns>
        static string[] getFormattedLineElements(string line) {
            return line.Split('|').Skip(1).Take(9).ToArray();
        }

        /// <summary>
        /// Takes a string and converts it to an integer
        /// </summary>
        /// <param name="element">The element to convert</param>
        /// <returns>Returns the converted to integer string. Returns 0 if string is empty space</returns>
        static int convertStringElementToBoardNumber(string element) {
            return element.Equals(" ") ? 0 : Convert.ToInt16(element);
        }
    }
}