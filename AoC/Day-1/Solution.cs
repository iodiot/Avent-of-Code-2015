using System;


namespace AoC.Day1
{
	/// <summary>
	/// --- Day 1: Not Quite Lisp ---
	/// </summary>
	public class Solution : AbstractSolution
	{
		public override void Run()
		{
			var text = System.IO.File.ReadAllText(@"Day-1/Input.txt");

			var counter = 0;
			var basementPos = -1;

			for (var i = 0; i < text.Length; ++i)
			{
				counter += (text[i] == '(') ? +1 : -1;

				if (counter == -1 && basementPos == -1)
				{
					basementPos = i + 1;
				}
			}

			Console.WriteLine($"Part 1: {counter}");
			Console.WriteLine($"Part 2: {basementPos}");
		}
	}
}
