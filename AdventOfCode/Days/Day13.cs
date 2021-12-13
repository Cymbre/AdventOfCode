using System;
using System.Collections.Generic;
using AdventOfCode.Util;

namespace AdventOfCode.Days
{
    public class Day13 : Day
    {
        private List<(int, int)> _input;
        private List<(char, int)> folds;
        private BitArray2D map;

        public Day13() : base()
        {
            _path = BasePath + "day13.txt";
            var input = FileReader.ReadFileToStringList(_path);

            _input = new List<(int, int)>();
            folds = new List<(char, int)>();

            var i = 0;

            while (!string.IsNullOrEmpty(input[i]))
            {
                var parts = input[i].Split(",");
                _input.Add((int.Parse(parts[0]), int.Parse(parts[1])));
                i++;
            }

            i++;

            var x = 0;
            var y = 0;

            while (i < input.Count)
            {
                var parts = input[i].Split(" ");
                var fold = parts[2].Split("=");

                if (fold[0][0] == 'x' && x == 0) x = int.Parse(fold[1]) * 2 + 1;
                if (fold[0][0] == 'y' && y == 0) y = int.Parse(fold[1]) * 2 + 1;

                folds.Add((fold[0][0], int.Parse(fold[1])));

                i++;
            }

            map = new BitArray2D(x, y);
            foreach (var (item1, item2) in _input)
            {
                map[item1, item2] = true;
            }
        }

        public override void PartOne()
        {
            var map = foldX(folds[0].Item2, this.map);
            Console.WriteLine(getTrueValueCounts(map));
        }

        private BitArray2D foldX(int line, BitArray2D oldMap)
        {
            BitArray2D foldedMap = new BitArray2D(line, oldMap.Dimension2);

            for (int y = 0; y < oldMap.Dimension2; y++)
            {
                for (int x = 0; x < oldMap.Dimension1; x++)
                {
                    if (x == line) continue;
                    if (x > line)
                    {
                        foldedMap[oldMap.Dimension1 - x - 1, y] = (
                            oldMap[x, y] | foldedMap[oldMap.Dimension1 - x - 1, y]);
                    }
                    else
                    {
                        foldedMap[x, y] = oldMap[x, y];
                    }
                }
            }

            return foldedMap;
        }

        private BitArray2D foldY(int line, BitArray2D oldMap)
        {
            BitArray2D foldedMap = new BitArray2D(oldMap.Dimension1, line);

            for (int y = 0; y < oldMap.Dimension2; y++)
            {
                if (y == line) continue;
                for (int x = 0; x < oldMap.Dimension1; x++)
                {
                    if (y > line)
                    {
                        foldedMap[x, oldMap.Dimension2 - y - 1] =
                            oldMap[x, y] | foldedMap[x, oldMap.Dimension2 - y - 1];
                    }
                    else
                    {
                        foldedMap[x, y] = oldMap[x, y];
                    }
                }
            }

            return foldedMap;
        }

        public override void PartTwo()
        {
            var foldedMap = this.map;
            foreach (var (item1, item2) in folds)
            {
                foldedMap = (item1 == 'x') ? foldX(item2, foldedMap) : foldY(item2, foldedMap);
            }

            foldedMap.printArray();
        }

        public int getTrueValueCounts(BitArray2D map)
        {
            var count = 0;
            for (int i = 0; i < map.Dimension1; i++)
            {
                for (int j = 0; j < map.Dimension2; j++)
                {
                    if (map[i, j]) count++;
                }
            }

            return count;
        }
    }
}