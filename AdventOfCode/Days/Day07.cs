using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Util;

namespace AdventOfCode.Days
{
    public class Day07 : Day
    {
        private List<int> _input;

        public Day07() : base()
        {
            _path = BasePath + "day07.txt";
            _input = FileReader.ReadFileToStringList(_path)[0]
                .Split(",")
                .Select(int.Parse)
                .ToList();
        }

        public override void PartOne()
        {
            var input = new List<int>(_input);

            var start = Util.Util.FindMedianInList(input);

            var minCost = CalculateCost(input, start);
            for (int i = 0; i < input.Count; i++)
            {
                if (minCost < CalculateCost(input, start + i)) break;
            }

            for (int i = 0; i < input.Count; i++)
            {
                if (minCost < CalculateCost(input, start - i)) break;
            }

            Console.WriteLine(minCost);
        }

        private static int CalculateCost(List<int> list, int start)
        {
            var sum = 0;
            foreach (var number in list)
            {
                if (number > start)
                {
                    sum += number - start;
                }
                else
                {
                    sum += start - number;
                }
            }

            return sum;
        }

        public override void PartTwo()
        {
            var input = new List<int>(_input);

            var start = Util.Util.FindMedianInList(input);

            var minCost = CalculateCostAtNotConstantRate(input, start);
            for (int i = 0; i < input.Count; i++)
            {
                var cost = CalculateCostAtNotConstantRate(input, start + i);
                if (start + i == input.Count || minCost < cost) break;
                minCost = cost;
                //Console.WriteLine(minCost + " " + cost + " " + i);
            }

            for (int i = 0; i < input.Count; i++)
            {
                var cost = CalculateCostAtNotConstantRate(input, start - i);
                if (start - i == 0 || minCost < cost) break;
                minCost = cost;
                //Console.WriteLine(minCost + " " + cost + " " + i);
            }

            Console.WriteLine(minCost);
        }

        private static int CalculateCostAtNotConstantRate(List<int> list, int start)
        {
            var sum = 0;
            foreach (var number in list)
            {
                if (number > start)
                {
                    sum += Util.Util.TriangularNumber(number - start);
                }
                else
                {
                    sum += Util.Util.TriangularNumber(start - number);
                }
            }

            return sum;
        }
    }
}