using System;
using System.Collections.Generic;
using System.Linq;

class Launcher
{
    private static List<int[]> selectedSets = new List<int[]>();

    static void Main(string[] args)
    {
        var universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
        var sets = new[]
        {
                new[] { 20 },
                new[] { 1, 5, 20, 30 },
                new[] { 3, 7, 20, 30, 40 },
                new[] { 9, 30 },
                new[] { 11, 20, 30, 40 },
                new[] { 3, 7, 40 }
            };

        var selectedSets = ChooseSets(sets.ToList(), universe.ToList());
        Console.WriteLine($"Sets to take ({selectedSets.Count}):");

        foreach (var set in selectedSets)
        {
            Console.WriteLine($"{{{string.Join(", ", set)}}}");
        }
    }

    private static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
    {
        while (universe.Count > 0)
        {
            // set which has thee most elements contained in the universe
            var biggestSet = sets.OrderByDescending(s => s.Count(universe.Contains))
                                 .First();

            selectedSets.Add(biggestSet);
            sets.Remove(biggestSet);

            //remove biggestSets elements from the universe
            biggestSet.ToList()
                      .ForEach(s => universe.Remove(s));
        }

        return selectedSets;
    }
}