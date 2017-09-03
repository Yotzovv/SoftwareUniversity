using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Knight_Game
{
    class Program
    {
        static bool[][] chessBoard;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            chessBoard = new bool[n][];

            //1. Get the stupid figures.
            for (int i = 0; i < n; i++) //col
            {
                var input = Console.ReadLine();
                chessBoard[i] = new bool[n];

                for (int e = 0; e < n; e++) //row
                {
                    if (input[e] == 'K')
                    {
                        chessBoard[i][e] = true;
                    }
                }
            }

            //2. Scan all figures.
            var threatenFigures = ScanAllFigures();

            //3. Bring peace to the chess board.
            int removedFigures = 0;

            while (true)
            {
                //1. Get the most threatened figure.
                var endangaredFigure = threatenFigures.OrderByDescending(f => f.Value).First();

                int row = endangaredFigure.Key.Keys.First();
                int col = endangaredFigure.Key.Values.First();
                int threats = endangaredFigure.Value;

                if(threats == 0)
                {
                    break;
                }

                chessBoard[row][col] = false;
                removedFigures++;

                threatenFigures = ScanAllFigures();
            }

            Console.WriteLine(removedFigures);
        }

        private static Dictionary<Dictionary<int, int>, int> ScanAllFigures()
        {
            var result = new Dictionary<Dictionary<int, int>, int>();   // row, figure, threats count

            for (int row = 0; row < chessBoard.Length; row++)
            {
                for (int col = 0; col < chessBoard[row].Length; col++)
                {
                    var figure = new Dictionary<int, int>();
                    figure[row] = col;

                    if (chessBoard[row][col])
                    {
                        result[figure] = ScanThreats(row, col);
                    }
                }
            }

            return result;
        }

        private static int ScanThreats(int row, int col)
        {
            int threatsCount = 0;

            // scan the upper left position
            try
            {
                if (chessBoard[row + 2][col - 1])
                {
                    threatsCount++;
                }
            } catch { }

            // scan the upper right position
            try
            {
                if (chessBoard[row + 2][col + 1])
                {
                    threatsCount++;
                }
            } catch { }

            // scan the down left position
            try
            {
                if (chessBoard[row - 2][col - 1])
                {
                    threatsCount++;
                }
            } catch { }

            // scan the down right position
            try
            {
                if (chessBoard[row - 2][col + 1])
                {
                    threatsCount++;
                }
            } catch { }

            // scan the right upper position
            try
            {
                if (chessBoard[row - 1][col + 2])
                {
                    threatsCount++;
                }
            } catch { }

            // scan the right down position
            try
            {
                if (chessBoard[row + 1][col + 2])
                {
                    threatsCount++;
                }
            } catch { }

            // scan the left upper position
            try
            {
                if (chessBoard[row - 1][col - 2])
                {
                    threatsCount++;
                }
            } catch { }

            // scan the left down position
            try
            {
                if (chessBoard[row + 1][col - 2])
                {
                    threatsCount++;
                }
            }   catch { }

            return threatsCount;
        }
    }
}
