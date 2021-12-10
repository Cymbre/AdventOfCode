using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Util;

namespace AdventOfCode.Days
{
    public class Day10 : Day
    {
        private List<string> _input;

        public Day10() : base()
        {
            _path = BasePath + "day10.txt";
            _input = FileReader.ReadFileToStringList(_path);
        }

        public override void PartOne()
        {
            var result = 0;
            for (int i = 0; i < _input.Count; i++)
            {
                var value = IllegalCharacter(i);
                Console.WriteLine(value);
                result += value;
            }

            Console.WriteLine(result);
            Console.WriteLine();
        }

        private int IllegalCharacter(int i)
        {
            var stack = new Stack<char>();

            for (int j = 0; j < _input[i].Length; j++)
            {
                switch (_input[i][j])
                {
                    case '(':
                        stack.Push(_input[i][j]);
                        break;
                    case '[':
                        stack.Push(_input[i][j]);
                        break;
                    case '{':
                        stack.Push(_input[i][j]);
                        break;
                    case '<':
                        stack.Push(_input[i][j]);
                        break;
                    case ')':
                        if ('(' != stack.Pop()) return 3;
                        break;
                    case ']':
                        if ('[' != stack.Pop()) return 57;
                        break;
                    case '}':
                        if ('{' != stack.Pop()) return 1197;
                        break;
                    case '>':
                        if ('<' != stack.Pop()) return 25137;
                        break;
                }
            }

            return 0;
        }

        private long FillMissing(int i)
        {
            var stack = new Stack<char>();

            for (var j = 0; j < _input[i].Length; j++)
            {
                switch (_input[i][j])
                {
                    case '(':
                        stack.Push(_input[i][j]);
                        break;
                    case '[':
                        stack.Push(_input[i][j]);
                        break;
                    case '{':
                        stack.Push(_input[i][j]);
                        break;
                    case '<':
                        stack.Push(_input[i][j]);
                        break;
                    case ')':
                        if ('(' != stack.Pop()) return 0;
                        break;
                    case ']':
                        if ('[' != stack.Pop()) return 0;
                        break;
                    case '}':
                        if ('{' != stack.Pop()) return 0;
                        break;
                    case '>':
                        if ('<' != stack.Pop()) return 0;
                        break;
                }
            }

            long score = 0;
            while (stack.Count > 0)
            {
                var bracket = stack.Pop() switch
                {
                    '(' => 1,
                    '[' => 2,
                    '{' => 3,
                    '<' => 4,
                    _ => 0
                };

                score = score * 5 + bracket;
            }

            return score;
        }


        public override void PartTwo()
        {
            var resultList = new List<long>();
            for (int i = 0; i < _input.Count; i++)
            {
                var value = FillMissing(i);
                Console.WriteLine(value);
                if (value > 0) resultList.Add(value);
            }

            Console.WriteLine(resultList.OrderBy(row => row).ToList()[resultList.Count / 2]);
        }
    }
}