using System;
using System.Collections.Generic;

namespace _06._8_Queens_Puzzle
{
    class Launcher
    {
        public class EightQueens
        {
            const int Size = 8;
            static bool[,] chessboard = new bool[Size, Size];
        }

        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedColumns = new HashSet<int>();
        static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        static void Main(string[] args)
        {
            PutQueents(0);
        }

        private static void PutQueents(int row)
        {
            throw new NotImplementedException();
        }

        private static void PrintSolution()
        {
            throw new NotImplementedException();
        }
    }
}
