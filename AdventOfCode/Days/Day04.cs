using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Util;

namespace AdventOfCode.Days
{
    public class Day04 : Day
    {
        private readonly List<int> _input;
        private List<List<List<int>>> bingos;

        public Day04()
        {
            _path = BasePath + "day04.txt";
            var input = FileReader.ReadFileToStringList(_path).ToList();

            _input = input[0].Split(",").ToList().Select(int.Parse).ToList();

            var bingo = input.GetRange(2, input.Count - 2);

            var bingoList = new List<List<string>>();
            var bingoCount = 0;
            bingoList.Add(new List<string>());
            foreach (var t in bingo)
            {
                if (string.IsNullOrEmpty(t))
                {
                    bingoCount++;
                    bingoList.Add(new List<string>());
                }
                else
                {
                    bingoList[bingoCount].Add(t);
                }
            }

            bingos = bingoList.Select(b => b
                .Select(row => row
                    .Split(" ").Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(int.Parse).ToList()).ToList()
            ).ToList();

            Console.WriteLine(bingoList);
        }

        public override void PartOne()
        {
            foreach (var number in _input)
            {
                foreach (var bingo in bingos)
                {
                    for (var i = 0; i < bingo.Count; i++)
                    {
                        for (var j = 0; j < bingo[0].Count; j++)
                        {
                            if (bingo[i][j] == number)
                            {
                                bingo[i][j] = -bingo[i][j];

                                if (CheckBingo(bingo, i, j))
                                {
                                    Console.WriteLine("bingo");
                                    var sum = bingo.Select(row => row.Where(y => y > 0).Sum()).Sum();
                                    Console.WriteLine(sum);
                                    Console.WriteLine(sum * number);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private static bool CheckBingo(IReadOnlyList<List<int>> bingo, int row, int column)
        {
            var checkRow = true;
            var checkColumn = true;
            for (int i = 0; i < bingo.Count; i++)
            {
                if (bingo[i][column] > 0)
                {
                    checkColumn = false;
                }

                if (bingo[row][i] > 0)
                {
                    checkRow = false;
                }

                if (!checkColumn && !checkRow) return false;
            }

            return true;
        }

        public override void PartTwo()
        {
            foreach (var number in _input)
            {
                for (var b = bingos.Count - 1; b >= 0; b--)
                {
                    var next = false;
                    for (var i = 0; i < bingos[0].Count; i++)
                    {
                        if (next) break;
                        for (var j = 0; j < bingos[0][0].Count; j++)
                        {
                            if (next) break;
                            if (bingos[b][i][j] == number)
                            {
                                bingos[b][i][j] = -bingos[b][i][j];

                                if (CheckBingo(bingos[b], i, j))
                                {
                                    if (bingos.Count == 1)
                                    {
                                        Console.WriteLine("bingo");
                                        var sum = bingos[0].Select(row => row.Where(y => y > 0).Sum()).Sum();
                                        Console.WriteLine(sum);
                                        Console.WriteLine(sum * number);
                                        return;
                                    }

                                    bingos.RemoveAt(b);
                                    next = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}