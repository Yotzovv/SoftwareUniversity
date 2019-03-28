using System;
using System.Collections.Generic;
using System.Linq;

class Launcher
{
    private static List<Task> tasks = new List<Task>();

    static void Main(string[] args)
    {
        int tasksCount = Console.ReadLine().Split().Select(int.Parse).Last();
        ReadTasks(tasksCount);
        ProcessTasks();
    }

    private static void ProcessTasks()
    {
        var result = tasks.OrderByDescending(v => v.Value)
                          .ThenBy(dl => dl.DeadLine)
                          .Take(tasks.Max(dl => dl.DeadLine))
                          .ToList();

        Console.Write("Optimal schedule: ");

        for (int i = 0; i < result.Count; i++)
        {
            Console.Write(tasks.IndexOf(result[i]) + 1 + (i == result.Count - 1 ? "" : " -> "));
        }
        Console.WriteLine();
        Console.WriteLine($"Total value: {result.Sum(v => v.Value)}");
    }

    private static void ReadTasks(int tasksCount, int index = 0)
    {
        if (index == tasksCount)
        {
            return;
        }
        var input = Console.ReadLine().Split(" - ").Select(int.Parse).ToArray();

        var task = new Task()
        {
            Value = input[0],
            DeadLine = input[1]
        };

        tasks.Add(task);

        ReadTasks(tasksCount, index + 1);
    }
}

public class Task
{
    public int Value { get; set; }

    public int DeadLine { get; set; }
}