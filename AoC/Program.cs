using System;

namespace AoC
{
	public abstract class AbstractSolution
	{
		public abstract void Run();
	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			var solution = new AoC.Day13.Solution();

			solution.Run();

			Console.Read();
		}
	}
}
