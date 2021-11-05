using System;
using System.Text;
using System.Linq;

namespace AoC.Day11
{
    /// <summary>
    /// --- Day 11: Corporate Policy ---
    /// </summary>
    public class Solution : AbstractSolution
    {
        private const string Input = "hxbxwxba";

        public override void Run()
        {
            var passwd = Input;

            var firstPasswd = String.Empty;

            while (true)
            {
                if (CheckPassword(passwd))
                {
                    if (firstPasswd == String.Empty)
                    {
                        firstPasswd = passwd;
                    }
                    else
                    {
                        break;
                    }
                }

                passwd = NextPassword(passwd);
            }

            Console.WriteLine($"First part: {firstPasswd}");
            Console.WriteLine($"Seconds part: {passwd}");
        }

        private static string NextPassword(string passwd)
        {
            var sb = new StringBuilder();

            var carry = true;

            for (var i = passwd.Length - 1; i >= 0; --i)
            {
                var ch = Convert.ToChar((passwd[i] - 'a' + 1) % ('z' - 'a' + 1) + 'a');
                sb.Append(carry ? ch : passwd[i]);
                carry &= passwd[i] == 'z';
            }

            return new String(sb.ToString().Reverse().ToArray());
        }

        private static bool CheckPassword(string passwd)
        {
            var ok = false;

            for (var i = 2; i < passwd.Length; ++i)
            {
                if ((passwd[i - 2] == (passwd[i - 1] - 1)) && (passwd[i - 1] == (passwd[i] - 1)))
                {
                    ok = true;
                    break;
                }
            }

            if (!ok)
            {
                return false;
            }

            if (passwd.Contains('i') || passwd.Contains('o') || passwd.Contains('l'))
            {
                return false;
            }

            var n = 1;
            var firstCh = '#';

            while (n < passwd.Length)
            {
                if (passwd[n - 1] == passwd[n])
                {
                    if (firstCh != '#' && firstCh != passwd[n])
                    {
                        return true;
                    }

                    firstCh = passwd[n];
                    ++n;
                }

                ++n;
            }

            return false;
        }
    }
}
