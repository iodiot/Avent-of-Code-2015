using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC.Day6
{
	/// <summary>
	/// --- Day 6: Probably a Fire Hazard ---
	/// </summary>
	public class Solution : AbstractSolution
	{
		private enum Instruction
		{
			Toggle,
			TurnOn,
			TurnOff
		}

		public override void Run()
		{
			Console.WriteLine($"First part: {RunInstructions(withBrightness: false)}");
			Console.WriteLine($"Second part: {RunInstructions(withBrightness: true)}");
		}

		public int RunInstructions(bool withBrightness)
		{
			var lines = System.IO.File.ReadAllLines(@"Day-6/Input.txt");

			var grid = new Dictionary<string, int>();

			foreach (var line in lines)
			{
				var tokens = line.Split(' ');

				var instr = (tokens[0] == "toggle") ? Instruction.Toggle
					: (tokens[1] == "on" ? Instruction.TurnOn : Instruction.TurnOff);

				var start = (instr == Instruction.Toggle) ? 1 : 2;

				var digits = $"{tokens[start]},{tokens[start + 2]}".Split(',').Select(s => Convert.ToInt32(s)).ToArray();
				

				int a = digits[0], b = digits[1], c = digits[2], d = digits[3];

		
				for (var j = b; j <= d; ++j)
				{
					for (var i = a; i <= c; ++i)
					{
						var key = $"{i}-{j}";

						if (!grid.ContainsKey(key))
						{
							grid[key] = 0;
						}

						switch (instr)
						{
							case Instruction.Toggle:
								if (withBrightness)
								{
									grid[key] += 2;
								}
								else
								{
									grid[key] = (grid[key] == 0) ? 1 : 0;
								}
								break;
							case Instruction.TurnOn:
								if (withBrightness)
								{
									grid[key] += 1;
								}
								else
								{
									grid[key] = 1;
								}
								break;
							case Instruction.TurnOff:
								if (withBrightness)
								{
									grid[key] = Math.Max(0, grid[key] - 1);
								}
								else
								{
									grid[key] = 0;
								}
								break;
						}
					}
				}
			}

			return grid.Values.Sum();
		}
	}
}
