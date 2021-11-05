using System;

namespace AoC.Day8
{
  /// <summary>
  /// --- Day 8: Matchsticks ---
  /// </summary>
	public class Solution : AbstractSolution
	{
    public override void Run()
    {
      Console.WriteLine($"First part: {RunFirstPart()}");
      Console.WriteLine($"Second part: {RunSecondPart()}");
    }

    private int RunFirstPart()
		{
      var lines = System.IO.File.ReadAllLines(@"Day-8/Input.txt");

      var count = 0;

      foreach (var line in lines)
      {
        count += line.Length;

        var i = 1;
        while (i < line.Length - 1)
        {
          i += (line[i] == '\\') ? (line[i + 1] == 'x' ? 4 : 2) : 1;
          count -= 1;
        }
      }

      return count;
		}

    private int RunSecondPart()
    {
      var lines = System.IO.File.ReadAllLines(@"Day-8/Input.txt");

      var count = 2 * lines.Length;

      foreach (var line in lines)
      {
        for (var i = 0; i < line.Length; ++i)
        {
          count += (line[i] == '\\' || line[i] == '\"') ? 1 : 0; 
        }
      }

      return count;
    }
	}
}
