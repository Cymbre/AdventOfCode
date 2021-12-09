using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Util;

namespace AdventOfCode.Days
{
    public class Day09 : Day
    {
        private List<List<int>> _input;

        public Day09() : base()
        {
            _path = BasePath + "day09.txt";
            _input = FileReader.ReadFileToStringList(_path)
                .Select(w => w.ToCharArray()
                    .Select(digit => int.Parse(digit.ToString())).ToList()
                ).ToList();
        }

        public override void PartOne()
        {
            var riskLevel = 0;
            for (var i = 0; i < _input.Count; i++)
            {
                for (var j = 0; j < _input[0].Count; j++)
                {
                    if (CheckLowPoint(i, j))
                    {
                        riskLevel += _input[i][j] + 1;
                    }
                }
            }

            Console.WriteLine(riskLevel);
        }

        private bool CheckLowPoint(int i, int j)
        {
            var value = _input[i][j];
            // left
            if (j > 0 && _input[i][j - 1] <= value) return false;
            // right
            if (j < _input[0].Count - 1 && _input[i][j + 1] <= value) return false;
            // up
            if (i > 0 && _input[i - 1][j] <= value) return false;
            // down
            if (i < _input.Count - 1 && _input[i + 1][j] <= value) return false;

            //Console.WriteLine(value + " " + i + " " + j);
            return true;
        }

        public override void PartTwo()
        {
            var basins = new List<int>();
            for (var i = 0; i < _input.Count; i++)
            {
                for (var j = 0; j < _input[0].Count; j++)
                {
                    if (CheckLowPoint(i, j))
                    {
                        var basinSize = FloodBasin(i, j);
                        basins.Add(basinSize);
                    }
                }
            }

            Console.WriteLine(basins.OrderByDescending(basin => basin)
                .ToList().GetRange(0, 3)
                .Aggregate(1, (x, y) => x * y));
        }

        private int FloodBasin(int i, int j)
        {
            if (i < 0 || i > _input.Count - 1 || j < 0 || j > _input[0].Count - 1) return 0;
            if (_input[i][j] == 9) return 0;

            var count = 1;
            _input[i][j] = 9;

            count += FloodBasin(i, j - 1); // left
            count += FloodBasin(i - 1, j); // up
            count += FloodBasin(i, j + 1); // right
            count += FloodBasin(i + 1, j); //down

            return count;
        }
    }
}