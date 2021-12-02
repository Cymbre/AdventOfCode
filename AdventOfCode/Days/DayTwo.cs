using System;
using System.Collections.Generic;
using AdventOfCode.Util;

namespace AdventOfCode.Days
{
    public class DayTwo : Day
    {
        private readonly List<Tuple<string, int>> _input;

        public DayTwo(string path) : base(path)
        {
            _input = FileReader.ReadFileToStringIntTupleList(path);
        }

        public override void PartOne()
        {
            var depth = 0;
            var horizontalPosition = 0;
            foreach (var (move, value) in _input)
            {
                switch (move)
                {
                    case "forward":
                        horizontalPosition += value;
                        break;
                    case "up":
                        depth -= value;
                        break;
                    case "down":
                        depth += value;
                        break;
                    default:
                        Console.WriteLine("Error: " + move + " / " + value);
                        break;
                }
            }

            Console.WriteLine(depth + " * " + horizontalPosition + " = " + (horizontalPosition * depth));
        }

        public override void PartTwo()
        {
            var depth = 0;
            var horizontalPosition = 0;
            var aim = 0;
            foreach (var (move, value) in _input)
            {
                switch (move)
                {
                    case "forward":
                        horizontalPosition += value;
                        depth += aim * value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                    case "down":
                        aim += value;
                        break;
                    default:
                        Console.WriteLine("Error: " + move + " / " + value);
                        break;
                }
            }

            Console.WriteLine(depth + " * " + horizontalPosition + " = " + (horizontalPosition * depth));
        }
    }
}