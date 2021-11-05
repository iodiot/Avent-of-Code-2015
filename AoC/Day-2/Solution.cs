using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC.Day2
{
    /// <summary>
    /// --- Day 2: I Was Told There Would Be No Math ---
    /// </summary>
    public class Solution : AbstractSolution
    {
        public override void Run()
        {
            RunFirstPart();
            RunSecondPart();
        }

        public void RunFirstPart()
        {
            var lines = System.IO.File.ReadAllLines(@"Day-2/Input.txt");

            var feets = 0;

            foreach (var line in lines)
            {
                var tokens = line.Split('x').Select(s => Convert.ToInt32(s)).ToArray();
                int w = tokens[0], h = tokens[1], l = tokens[2];
                var areas = new List<int> { w * h, w * l, h * l };
                areas.Sort();
                feets += 2 * (areas[0] + areas[1] + areas[2]) + areas[0];
            }

            Console.WriteLine($"First part: {feets}");
        }

        public void RunSecondPart()
        {
            var lines = System.IO.File.ReadAllLines(@"Day-2/Input.txt");

            var feets = 0;

            foreach (var line in lines)
            {
                var sides = line.Split('x').Select(s => Convert.ToInt32(s)).ToList();
                sides.Sort();
                feets += 2 * (sides[0] + sides[1]) + sides[0] * sides[1] * sides[2];
            }

            Console.WriteLine($"Second part: {feets}");
        }
    }
}
