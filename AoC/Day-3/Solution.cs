using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Day3
{
	public class Position
	{
		public int X;
		public int Y;
	}

	/// <summary>
	/// --- Day 3: Perfectly Spherical Houses in a Vacuum ---
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
			var moves = System.IO.File.ReadAllText(@"Day-3/Input.txt");

			var map = new Dictionary<string, int>();
			var x = 0;
			var y = 0;

			for (var i = 0; i < moves.Length; ++i)
			{
				var key = $"{x}-{y}";
				if (map.ContainsKey(key))
				{
					map[key] += 1;
				}
				else
				{
					map[key] = 1;
				}

				switch (moves[i])
				{
					case '<':
						x -= 1;
						break;
					case '>':
						x += 1;
						break;
					case '^':
						y -= 1;
						break;
					case 'v':
						y += 1;
						break;
				}
			}

			Console.WriteLine($"First part: {map.Values.Count}");
		}

		public void RunSecondPart()
		{
			var moves = System.IO.File.ReadAllText(@"Day-3/Input.txt");

			var map = new Dictionary<string, int>();
			var santa = new Position();
			var robo = new Position();

			for (var i = 0; i < moves.Length; ++i)
			{
				var who = ((i % 2) == 0) ? santa : robo;

				var key = $"{who.X}-{who.Y}";
				if (map.ContainsKey(key))
				{
					map[key] += 1;
				}
				else
				{
					map[key] = 1;
				}

				switch (moves[i])
				{
					case '<':
						who.X -= 1;
						break;
					case '>':
						who.X += 1;
						break;
					case '^':
						who.Y -= 1;
						break;
					case 'v':
						who.Y += 1;
						break;
				}
			}

			Console.WriteLine($"Second part: {map.Values.Count}");
		}
	}
}
