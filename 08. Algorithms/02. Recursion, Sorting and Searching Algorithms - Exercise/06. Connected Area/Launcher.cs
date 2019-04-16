using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Connected_Area
{
    class Launcher
    {
        private static char[,] matrix;
        private static SortedSet<Area> areas = new SortedSet<Area>();

        static void Main(string[] args)
        {
            ReadInput();
            FindAreas();
            PrintOutput();
        }

        private static void FindAreas()
        {
            Area area = new Area();
            area.Cordinates = FindCordinates();
            area.Size = FindSize(area);

            areas.Add(area);
        }

        private static void PrintOutput()
        {
            Console.WriteLine($"Total areas found: {areas.Count}");

            for (int i = 0; i < areas.Count; i++)
            {
                var area = areas.ElementAt(i);

                Console.WriteLine($"Area #{i + 1} at ({area.Cordinates.Row}, {area.Cordinates.Col}), size: {area.Size}");
            }
        }

        private static int FindSize(Area area)
        {
            if (area.Cordinates == null)
            {
                return 0;
            }

            int size = 0;

            for (int row = area.Cordinates.Row; row < matrix.GetLength(0); row++)
            {
                for (int col = area.Cordinates.Col; col <= matrix.GetLength(1); col++)
                {
                    //If cell is border
                    if (matrix[row, col] == '*')
                    {
                        break; //go to next row
                    }

                    //If cell is discovered
                    if(areas.Any(a => a.Cells.Any(c => c.Row == row && c.Col == col)))
                    {
                        continue; //go to next col
                    }

                    size++;

                    area.Cells.Add(new Cell() { Row = row, Col = col });
                }
            }

            return size;
        }

        private static Cell FindCordinates()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(row); col++)
                {
                    if (AreaIsUndiscovered(row, col) && matrix[row, col] != '*')
                    {
                        return new Cell() { Row = row, Col = col };
                    }
                }
            }

            return null;
        }

        private static void ReadInput()
        {
            //Read PARAMETERS
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            //Read MATRIX
            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();

                for (int i = 0; i < input.Length; i++)
                {
                    matrix[row, i] = input[i];
                }
            }
        }

        public static bool AreaIsUndiscovered(int row, int col)
            => areas.Any(a => a.Cordinates.Row == row && a.Cordinates.Col == col) == false;
    }

    class Area
    {
        public Cell Cordinates { get; set; }

        public List<Cell> Cells { get; set; }

        public int Size { get; set; }
    }

    class Cell
    {
        public int Row { get; set; }

        public int Col { get; set; }
    }
}