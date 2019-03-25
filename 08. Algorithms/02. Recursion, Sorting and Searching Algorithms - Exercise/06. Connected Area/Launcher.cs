using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Connected_Area
{
    class Launcher
    {
        private static char[,] matrix;
        private static List<Area> Areas;

        static void Main(string[] args)
        {
            ReadMatrix();
            AnalyzeAreas();
        }

        private static void AnalyzeAreas(int row = 0)
        {
            if (matrix.Length > row)
            {
                return;
            }

            for (int col = 0; col < matrix.GetLength(row); col++)
            {
                if (matrix[row, col] != '*')
                {

                }
            }

            AnalyzeAreas(row + 1);
        }

        private static void ReadMatrix()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }
    }

    class Area
    {
        public List<Cell> Cells { get; set; }
    }

    public class Cell
    {
        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }

        int Row { get; set; }

        int Col { get; set; }
    }
}