using SudokuSolver.Strategies;
using SudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SudokuMapper sudokuMapper = new SudokuMapper();
                SudokuBoardStateManager sudokuBoardStateManager = new SudokuBoardStateManager();
                SudokuSolverEngine sudokuSolverEngine = new SudokuSolverEngine(sudokuBoardStateManager, sudokuMapper);
                SudokuFileReader sudokuFileReader = new SudokuFileReader();
                SudokuBoardDisplayer sudokuBoardDisplayer = new SudokuBoardDisplayer();

                Console.WriteLine("Please enter the filename containing the Sudoku Puzzle: ");
                var fileName = Console.ReadLine() ?? string.Empty;

                var sudokuBoard = sudokuFileReader.ReadFile(fileName);
                sudokuBoardDisplayer.Display("Initial State", sudokuBoard);

                var isSudokuSolved = sudokuSolverEngine.Solve(sudokuBoard);
                sudokuBoardDisplayer.Display("Final State", sudokuBoard);

                Console.WriteLine(isSudokuSolved
                    ? "You have successfully solved this Sudoku Puzzle"
                    : "Unfortunately, Current algorithm(s) were not enough to solve the current sudoku puzzle!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0} : {1}", "Sudoku Puzzle cannot be solved because there was an error",ex.Message);
            }
        }
    }
}
