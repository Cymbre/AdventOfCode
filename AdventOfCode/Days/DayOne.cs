using System;
using System.Collections.Generic;
using AdventOfCode.Util;

namespace AdventOfCode.Days
{
    public class DayOne : Day
    {
        private readonly List<int> _input;

        public DayOne(string path) : base(path)
        {
            _input = FileReader.ReadFileToIntList(path);
        }

        public override void PartOne()
        {
            var count = 0;
            for (var i = 1; i < _input.Count; i++)
            {
                if (_input[i] - _input[i - 1] > 0)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        public override void PartTwo()
        {
            var count = 0;
            for (var i = 0; i < _input.Count - 3; i++)
            {
                if (_input[i + 3] - _input[i] > 0)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}