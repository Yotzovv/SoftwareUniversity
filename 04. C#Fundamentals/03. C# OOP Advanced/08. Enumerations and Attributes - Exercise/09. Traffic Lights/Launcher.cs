using _09.Traffic_Lights.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Traffic_Lights
{
    class Launcher
    {
        static void Main(string[] args)
        {
            List<TrafficLight> trafficLights = ReadLights();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                trafficLights.ForEach(l => l.Cycle());

                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }

        private static List<TrafficLight> ReadLights()
        {
            string[] input = Console.ReadLine().Split();
            List<TrafficLight> trafficLights = new List<TrafficLight>();

            foreach (var item in input)
            {
                TrafficLight light = new TrafficLight(item);
                trafficLights.Add(light);
            }

            return trafficLights;
        }
    }
}
