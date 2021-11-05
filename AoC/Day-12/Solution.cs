using System;
using System.Text;
using System.IO;

namespace AoC.Day12
{
    /// <summary>
    /// --- Day 12: JSAbacusFramework.io ---
    /// </summary>
    public class Solution : AbstractSolution
    {
        public override void Run()
        {
            var text = System.IO.File.ReadAllText(@"Day-12/Input.txt");

            Console.WriteLine($"First part: {ReadJson(text, ignoreObjectsWithRedValue: false)}");
            Console.WriteLine($"First part: {ReadJson(text, ignoreObjectsWithRedValue: true)}");
        }

        private int ReadJson(string text, bool ignoreObjectsWithRedValue)
        {
            text = text.Trim();

            var reader = new StringReader(text[0] == '{' ? text : '{' + text + '}');

            return ReadObject(reader, ignoreObjectsWithRedValue);
        }

        private int ReadObject(StringReader reader, bool ignoreObjectsWithRedValue)
        {
            var sum = 0;
            var isReadingValue = false;
            var hasRedValue = false;

            reader.Read(); // {

            while (true)
            {
                char ch = Convert.ToChar(reader.Peek());

                if (ch == '{')
                {
                    sum += ReadObject(reader, ignoreObjectsWithRedValue);
                }
                if (ch == '}')
                {
                    break;
                }
                else if (ch == '[')
                {
                    sum += ReadArray(reader, ignoreObjectsWithRedValue);
                }
                else if (ch == '\"')
                {
                    var str = ReadField(reader);
                    if (isReadingValue && str == "red")
                    {
                        hasRedValue = true;
                    }
                }
                else if (Char.IsDigit(ch) || ch == '-')
                {
                    sum += ReadDigit(reader);
                }
                else if (ch == ',')
                {
                    reader.Read();  // ,
                    isReadingValue = false;
                }
                else if (ch == ':')
                {
                    reader.Read();  // :
                    isReadingValue = true;
                }
            }

            reader.Read(); // }

            return hasRedValue && ignoreObjectsWithRedValue ? 0 : sum;
        }

        private string ReadField(StringReader reader)
        {
            var str = String.Empty;

            reader.Read();  // "

            while (true)
            {
                char ch = Convert.ToChar(reader.Peek());

                if (ch == '\"')
                {
                    break;
                }

                str += ch;
                reader.Read();
            }

            reader.Read();  // "

            return str;
        }

        private int ReadArray(StringReader reader, bool ignoreObjectsWithRedValue)
        {
            var sum = 0;

            reader.Read();  // [

            while (true)
            {
                char ch = Convert.ToChar(reader.Peek());

                if (ch == '[')
                {
                    sum += ReadArray(reader, ignoreObjectsWithRedValue);
                }
                else if (ch == ']')
                {
                    break; 
                }
                else if (ch == '{')
                {
                    sum += ReadObject(reader, ignoreObjectsWithRedValue);
                }
                else if (ch == ',')
                {
                    reader.Read(); // ,
                }
                else if (Char.IsDigit(ch) || ch == '-')
                {
                    sum += ReadDigit(reader);
                }
                else if (ch == '\"')
                {
                    var str = ReadField(reader);
                }
            }

            reader.Read(); // ]

            return sum;
        }

        private int ReadDigit(StringReader reader)
        {
            var strInt = String.Empty;

            while (true)
            {
                char ch = Convert.ToChar(reader.Peek());

                if (ch == ',' || ch == ']' || ch == '}')
                {
                    break;
                }

                strInt += ch;
                reader.Read();
            }

            return Convert.ToInt32(strInt);
        }
    }
}
