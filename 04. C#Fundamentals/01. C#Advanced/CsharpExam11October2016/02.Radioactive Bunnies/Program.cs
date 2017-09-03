using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Radioactive_Bunnies
{
    class Program
    {
        static Dictionary<int, char[]> fields;
        static int[] player;

        static void Main(string[] args)
        {
            fields = new Dictionary<int, char[]>();
            player = new int[2];

            GetInput();
            Move();
        }

        private static void Move()
        {
            var moves = Console.ReadLine();

            foreach (var direction in moves)
            {
                    if (direction == 'U')
                    {
                        player[0] -= 1;
                    }
                    else if (direction == 'D')
                    {
                        player[0] += 1;
                    }
                    else if (direction == 'L')
                    {
                        player[1] -= 1;
                    }
                    else if (direction == 'R')
                    {
                        player[1] += 1;
                    }

                    MultiplyBunnies();

                    if (player[0] < 0 || player[0] >= fields.Count || player[1] < 0 || player[1] >= fields.Values.First().Count())
                    {
                        PrintWin();
                        return;
                    }
                    else if (fields[player[0]][player[1]] == 'B')
                    {
                        PrintLost();
                        return;
                    }
            }          
        }

        private static void PrintLost()
        {
            foreach (var row in fields)
            {
                Console.WriteLine(string.Join("", row.Value));
            }

            int x = player[0];
            int y = player[1];

            if (x < 0 || x > fields.Count)
            {
                x = x < 0 ? 0 : fields.Count - 1;
            }
            else
            {
                x = player[0];
            }

            if (y < 0 || y > fields.Values.First().Count() - 1)
            {
                y = y < 0 ? 0 : fields.Values.First().Count() - 1;
            }
            else
            {
                y = player[1];
            }

            Console.WriteLine($"dead: {x} {y}");
            return;
        }

        private static void PrintWin()
        {
            foreach (var row in fields)
            {
                Console.WriteLine(string.Join("", row.Value));
            }

            int x = player[0];
            int y = player[1];

            if (x < 0 || x > fields.Count - 1)
            {
                x = x < 0 ? 0 : fields.Count - 1;
            }

            if (y < 0 || y > fields.Values.First().Count() - 1)
            {
                y = y < 0 ? 0 : fields.Values.First().Count() - 1;
            }

            Console.WriteLine($"won: {x} {y}");
            return;
        }

        private static void MultiplyBunnies()
        {
            var newLair = new Dictionary<int, char[]>();

            for (int i = 0; i < fields.Count; i++)
            {
                newLair[i] = (char[])fields[i].Clone();
            }

            for (int x = 0; x < fields.Count; x++)
            {
                for (int y = 0; y < fields[x].Count(); y++)
                {
                    if (!fields[x].Any(c => c == 'B'))
                    {
                        break;
                    }

                    if (fields[x][y] == 'B')
                    {
                        if (x > 0) newLair[x - 1][y] = 'B';
                        if (x < fields.Count - 1) newLair[x + 1][y] = 'B';
                        if (y > 0) newLair[x][y - 1] = 'B';
                        if (y < fields.Values.First().Count() - 1) newLair[x][y + 1] = 'B';
                    }
                }
            }

            fields = newLair;
        }

        private static void GetInput()
        {
            int[] xy = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int x = 0; x < xy[0]; x++)
            {
                fields[x] = new char[xy[1]];

                var field = Console.ReadLine().ToCharArray();

                if (field.Contains('P'))
                {
                    player[0] = x;
                    player[1] = Array.IndexOf(field, 'P');
                    field[player[1]] = '.';
                }

                fields[x] = field;
            }
        }
    }
}
