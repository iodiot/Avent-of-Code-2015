using System;
using System.Text;

namespace AoC.Day10
{
  /// <summary>
  /// --- Day 10: Elves Look, Elves Say ---
  /// </summary>
	public class Solution : AbstractSolution
	{
    private const string input = "1321131112";

    public override void Run()
    {
      var oldStr = new StringBuilder($"{input}z");
      var n = 1;

      var lengthAfter40Times = -1;

      for (var times = 0; times < 50; ++times)
      {
        if (times == 40)
        {
          lengthAfter40Times = oldStr.Length - 1;
        }

        var newStr = new StringBuilder();

        for (var i = 0; i < oldStr.Length - 1; ++i)
        {
          if (oldStr[i] == oldStr[i + 1])
          {
            n += 1;
          }
          else
          {
            newStr.Append($"{n}{oldStr[i]}");
            n = 1;
          }
        }

        oldStr = new StringBuilder($"{newStr}z");
      }

      Console.WriteLine($"First part: {lengthAfter40Times}");
      Console.WriteLine($"Second part: {oldStr.Length - 1}");
  
		}
	}
}
