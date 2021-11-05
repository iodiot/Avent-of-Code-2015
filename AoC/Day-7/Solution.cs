using System;
using System.Collections.Generic;

namespace AoC.Day7
{
    /// <summary>
    /// --- Day 7: Some Assembly Required ---
    /// </summary>
    public class Solution : AbstractSolution
    {
        private enum InstrType
        {
            None,
            SetValue,
            And,
            Or,
            Not,
            LShift,
            RShift
        }

        private class Instruction
        {
            public InstrType Type;
            public string Left;
            public string Right;
        }

        public override void Run()
        {
            var wires = ReadInput();

            var signalOnWireA = GetSignal("a", wires, new Dictionary<string, ushort>());

            wires["b"].Left = Convert.ToString(signalOnWireA);

            Console.WriteLine($"First part: {signalOnWireA}");
            Console.WriteLine($"Second part: { GetSignal("a", wires, new Dictionary<string, ushort>())}");
        }

        private ushort GetSignal(string wireName, Dictionary<string, Instruction> wires, Dictionary<string, ushort> memory)
        {
            if (memory.ContainsKey(wireName))
            {
                return memory[wireName];
            }

            if (Char.IsDigit(wireName[0]))
            {
                return Convert.ToUInt16(wireName);
            }

            var instr = wires[wireName];

            ushort result = 0;

            var left = (ushort)GetSignal(instr.Left, wires, memory);
            var right = (ushort)GetSignal(instr.Right, wires, memory);

            switch (instr.Type)
            {
                case InstrType.And:
                    result = (ushort)(left & right);
                    break;
                case InstrType.Or:
                    result = (ushort)(left | right);
                    break;
                case InstrType.SetValue:
                    result = left;
                    break;
                case InstrType.Not:
                    result = (ushort)~left;
                    break;
                case InstrType.LShift:
                    result = (ushort)(left << right);
                    break;
                case InstrType.RShift:
                    result = (ushort)(left >> right);
                    break;
                case InstrType.None:
                    break;
            }

            memory[wireName] = result;
            return result;
        }

        private Dictionary<string, Instruction> ReadInput()
        {
            var lines = System.IO.File.ReadAllLines("Day-7/Input.txt");

            var wires = new Dictionary<string, Instruction>();

            foreach (var line in lines)
            {
                var tokens = line.Split(new string[] { "->" }, StringSplitOptions.None);

                var expr = tokens[0].Trim(new char[] { ' ' });
                var result = tokens[1];
                var instrType = InstrType.None;
                string left = "0", right = "0";

                var exprLength = expr.Split(' ').Length;

                if (exprLength == 1)
                {
                    instrType = InstrType.SetValue;
                    left = expr;
                }
                else if (exprLength == 2)
                {
                    instrType = InstrType.Not;
                    left = expr.Split(' ')[1];
                }
                else
                {
                    tokens = expr.Split(' ');
                    left = tokens[0];
                    right = tokens[2];
                    instrType = (tokens[1] == "AND") ? InstrType.And
                      : (tokens[1] == "OR" ? InstrType.Or : (tokens[1] == "LSHIFT" ? InstrType.LShift : InstrType.RShift));
                }

                left = left.Trim(new char[] { ' ' });
                right = right.Trim(new char[] { ' ' });
                result = result.Trim(new char[] { ' ' });

                wires[result] = new Instruction { Type = instrType, Left = left, Right = right };
            }

            return wires;
        }
    }
}
