using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Day9
{
    /// <summary>
    /// --- Day 9: All in a Single Night ---
    /// </summary>
    public class Solution : AbstractSolution
    {

        public override void Run()
        {
            Console.WriteLine($"First part: {FindRoute(toFindMinRoute: true)}");
            Console.WriteLine($"Second part: {FindRoute(toFindMinRoute: false)}");
        }

        public (int, string) FindRoute(bool toFindMinRoute)
        {
            var places = new List<string>();
            var distances = new Dictionary<string, int>();

            var lines = System.IO.File.ReadAllLines(@"Day-9/Input.txt");

            foreach (var line in lines)
            {
                var tokens = line.Split(' ');

                places.Add(tokens[0]);
                places.Add(tokens[2]);

                distances.Add(HashFromTo(tokens[0], tokens[2]), Convert.ToInt32(tokens[4]));
            }

            places = places.Distinct().ToList();

            var queue = new Queue<List<string>>();

            foreach (var place in places)
            {
                queue.Enqueue(new List<string> { place });
            }

            List<string> optRoute = null;
            var optDistance = toFindMinRoute ? Int32.MaxValue : 0;

            while (queue.Count > 0)
            {
                var route = queue.Dequeue();

                if (route.Count < places.Count)
                {
                    foreach (var place in places)
                    {
                        if (!route.Contains(place))
                        {
                            var routeDup = route.ToList();
                            routeDup.Add(place);
                            queue.Enqueue(routeDup);
                        }
                    }
                }
                else
                {
                    var d = ComputeDistance(route, distances);

                    if ((toFindMinRoute && d < optDistance) || (!toFindMinRoute && d > optDistance))
                    {
                        optDistance = d;
                        optRoute = route;
                    }
                }
            }

            var optRouteStr = String.Empty;
            foreach (var place in optRoute)
            {
                optRouteStr += $"{place} -> ";
            }

            return (optDistance, optRouteStr.Substring(0, optRouteStr.Length - 4));
        }

        private static int ComputeDistance(List<string> route, Dictionary<string, int> distances)
        {
            var distance = 0;

            for (var i = 0; i < route.Count - 1; ++i)
            {
                distance += distances[HashFromTo(route[i], route[i + 1])];
            }

            return distance;
        }

        private static string HashFromTo(string from, string to)
        {
            var places = new List<string> { from, to };
            places.Sort();
            return $"{places[0]}-{places[1]}";
        }
    }
}
