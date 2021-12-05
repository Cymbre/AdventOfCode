using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AdventOfCode.Util;

namespace AdventOfCode.Days
{
    public class Day02 : Day
    {
        private readonly List<Tuple<string, int>> _input;

        public Day02() : base()
        {
            string pattern = @"(\w+)\s(\d)";
            _path = BasePath + "day02.txt";
            _input = FileReader.ReadFileToObjectListWithRegex(_path, pattern, Parser);
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

        private static Tuple<string, int> Parser(GroupCollection groupCollection)
        {
            return new Tuple<string, int>(groupCollection[1].Value, int.Parse(groupCollection[2].Value));
        }
    }
}