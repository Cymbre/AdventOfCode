using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Util;

namespace AdventOfCode.Days
{
    public class Day11 : Day
    {
        private List<List<int>> _input;

        public Day11() : base()
        {
            _path = BasePath + "day11.txt";
            _input = FileReader.ReadFileToStringList(_path)
                .Select(w => w.ToCharArray()
                    .Select(digit => int.Parse(digit.ToString())).ToList()
                ).ToList();
        }

        public override void PartOne()
        {
            var uplights = 0;
            var days = 100;
            for (int dayCount = 0; dayCount < days; dayCount++)
            {
                for (int rIndex = 0; rIndex < _input.Count; rIndex++)
                {
                    for (int cIndex = 0; cIndex < _input[rIndex].Count; cIndex++)
                    {
                        uplights += LightUp(rIndex, cIndex);
                    }
                }

                for (int rIndex = 0; rIndex < _input.Count; rIndex++)
                {
                    for (int cIndex = 0; cIndex < _input[rIndex].Count; cIndex++)
                    {
                        Console.Write(_input[rIndex][cIndex] + " ");
                        if (_input[rIndex][cIndex] >= 10) _input[rIndex][cIndex] = 0;
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            Console.WriteLine(uplights);
        }

        private int LightUp(int rIndex, int cIndex)
        {
            _input[rIndex][cIndex]++;
            var lightups = 0;
            if (_input[rIndex][cIndex] != 10) return lightups;

            lightups++;

            if (rIndex > 0) lightups += LightUp(rIndex - 1, cIndex);
            if (rIndex > 0 && cIndex > 0) lightups += LightUp(rIndex - 1, cIndex - 1);
            if (rIndex > 0 && cIndex < _input[rIndex].Count - 1) lightups += LightUp(rIndex - 1, cIndex + 1);

            if (cIndex > 0) lightups += LightUp(rIndex, cIndex - 1);

            if (rIndex < _input.Count - 1) lightups += LightUp(rIndex + 1, cIndex);
            if (rIndex < _input.Count - 1 && cIndex > 0) lightups += LightUp(rIndex + 1, cIndex - 1);
            if (rIndex < _input.Count - 1 && cIndex < _input[rIndex].Count - 1)
                lightups += LightUp(rIndex + 1, cIndex + 1);

            if (cIndex < _input[rIndex].Count - 1) lightups += LightUp(rIndex, cIndex + 1);

            return lightups;
        }


        public override void PartTwo()
        {
            _input = FileReader.ReadFileToStringList(_path)
                .Select(w => w.ToCharArray()
                    .Select(digit => int.Parse(digit.ToString())).ToList()
                ).ToList();

            var uplights = 0;
            var days = 0;
            var allFlashed = false;
            while (!allFlashed)
            {
                for (int rIndex = 0; rIndex < _input.Count; rIndex++)
                {
                    for (int cIndex = 0; cIndex < _input[rIndex].Count; cIndex++)
                    {
                        uplights += LightUp(rIndex, cIndex);
                    }
                }

                allFlashed = true;
                for (int rIndex = 0; rIndex < _input.Count; rIndex++)
                {
                    for (int cIndex = 0; cIndex < _input[rIndex].Count; cIndex++)
                    {
                        //Console.Write(_input[rIndex][cIndex] + " ");
                        if (_input[rIndex][cIndex] >= 10)
                        {
                            _input[rIndex][cIndex] = 0;
                        }
                        else
                        {
                            allFlashed = false;
                        }
                    }
                }

                days++;
            }

            Console.WriteLine(days);
        }
    }
}