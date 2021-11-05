using System;
using System.Security.Cryptography;
using System.Text;

namespace AoC.Day4
{
	/// <summary>
	/// --- Day 4: The Ideal Stocking Stuffer ---
	/// </summary>
	public class Solution : AbstractSolution
	{
		private const string input = "bgvyzdsv";

		public override void Run()
		{
			var n = 1;

			var fiveZeros = -1;
			var sixZeros = -1;

			while (true)
			{
				var hash = GetHexHash($"{input}{n}");

				if (hash.StartsWith("00000"))
				{
					if (fiveZeros == -1)
					{
						fiveZeros = n;
					}

					if (hash.StartsWith("000000"))
					{
						sixZeros = n;
						break;
					}
				}

				n += 1;
			}

			Console.WriteLine($"First part: {fiveZeros}");
			Console.WriteLine($"Second part: {sixZeros}");
		}

		private string GetHexHash(string input)
		{
			// Use input string to calculate MD5 hash
			using (MD5 md5 = MD5.Create())
			{
				byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
				byte[] hashBytes = md5.ComputeHash(inputBytes);

				// Convert the byte array to hexadecimal string
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					sb.Append(hashBytes[i].ToString("x2"));
				}
				return sb.ToString();
			}
		}
	}
}
