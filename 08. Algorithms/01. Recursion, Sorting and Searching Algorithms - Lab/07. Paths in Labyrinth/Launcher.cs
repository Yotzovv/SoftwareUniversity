using System;
using System.Collections.Generic;

namespace _07._Paths_in_Labyrinth
{
    class Launcher
    {
        static List<char> path = new List<char>();

        public static char[][] lab = null;

        static void Main(string[] args)
        {
            lab = ReadLab();
            FindPaths(0, 0, 'S');
        }

        private static void FindPaths(int row, int col, char direction)
        {
            if(!IsInBounds(row, col))
            {
                return;
            }

            if(IsExit(row, col))
            {
                PrintPath();
            }
            else if(!IsVisited(row, col) && IsFree(row, col))
            {
                Mark(row, col);
                FindPaths(row, col + 1, 'R');
                FindPaths(row + 1, col, 'D');
                FindPaths(row, col - 1, 'L');
                FindPaths(row - 1, col, 'U');
                Unmark(row, col);
            }

            path.RemoveAt(path.Count - 1);
        }

        private static void Unmark(int row, int col)
        {
            throw new NotImplementedException();
        }

        private static void Mark(int row, int col)
        {
            throw new NotImplementedException();
        }

        private static bool IsVisited(int row, int col)
        {
            throw new NotImplementedException();
        }

        private static bool IsFree(int row, int col)
        {
            throw new NotImplementedException();
        }

        private static void PrintPath()
        {
            throw new NotImplementedException();
        }

        private static bool IsExit(int row, int col)
        {
            throw new NotImplementedException();
        }

        private static bool IsInBounds(int row, int col)
        {
            throw new NotImplementedException();
        }

        private static char[][] ReadLab()
        {
            throw new NotImplementedException();
        }
    }
}
