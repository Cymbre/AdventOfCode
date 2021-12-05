using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Util;

namespace AdventOfCode.Days
{
    public class DayThree : Day
    {
        private readonly List<List<int>> _input;

        public DayThree()
        {
            _path = BasePath + "day3.txt";
            _input = FileReader.ReadFileToStringList(_path)
                .Select(w => w.ToCharArray()
                    .Select(c => int.Parse(c.ToString())).ToList())
                .ToList();
        }

        public override void PartOne()
        {
            var input = new List<List<int>>(_input);
            input = input.Transpose();
            var result = "";
            foreach (var row in input)
            {
                if (row.Sum() > row.Count / 2)
                {
                    result += "1";
                }
                else
                {
                    result += "0";
                }
            }

            var gamma = Convert.ToInt32(result, 2);
            var epsilon = 4095 - gamma;
            Console.WriteLine("gamma:" + gamma);
            Console.WriteLine("epsilon:" + epsilon);
            Console.WriteLine("consumption:" + gamma * epsilon);
        }

        public override void PartTwo()
        {
            var leastCommonList = new List<List<int>>(_input);
            var pos = PartTwoRecursive(_input, 0, 1);
            var neg = PartTwoRecursive(leastCommonList, 0, -1);

            var gamma = Convert.ToInt32(string.Join("", pos), 2);
            var epsilon = Convert.ToInt32(string.Join("", neg), 2);

            Console.WriteLine("gamma:" + gamma);
            Console.WriteLine("epsilon:" + epsilon);
            Console.WriteLine("consumption:" + (gamma * epsilon));
        }

        private static List<int> PartTwoRecursive(IList<List<int>> input, int collumn, int mode)
        {
            if (input.Count == 1) return input[0];

            var oneList = new List<List<int>>();
            var nullList = new List<List<int>>();

            foreach (var t in input)
            {
                if (t[collumn] == 1)
                {
                    oneList.Add(t);
                }
                else
                {
                    nullList.Add(t);
                }
            }

            //Console.WriteLine(input.Count + ", " + oneList.Count + ", " + nullList.Count);
            if (oneList.Count == nullList.Count)
            {
                if (mode == 1)
                {
                    return PartTwoRecursive(oneList, collumn + 1, mode);
                }

                return PartTwoRecursive(nullList, collumn + 1, mode);
            }

            if (oneList.Count * mode >= nullList.Count * mode)
            {
                return PartTwoRecursive(oneList, collumn + 1, mode);
            }

            return PartTwoRecursive(nullList, collumn + 1, mode);
        }
    }
}

}