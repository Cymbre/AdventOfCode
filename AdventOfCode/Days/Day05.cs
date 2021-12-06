using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AdventOfCode.Util;

namespace AdventOfCode.Days
{
    public class Day05 : Day
    {
        private readonly List<Tuple<int, int, int, int>> _input;

        public Day05() : base()
        {
            string pattern = @"(\d+),(\d+)\s\->\s(\d+),(\d+)";
            _path = BasePath + "day05.txt";
            _input = FileReader.ReadFileToObjectListWithRegex(_path, pattern, Parser);
        }

        public override void PartOne()
        {
            var size = 1000;
            var area = new int[size, size];
            foreach (var (x1, y1, x2, y2) in _input)
            {
                if (x1 == x2)
                {
                    if (y1 < y2)
                    {
                        for (var i = y1; i <= y2; i++)
                        {
                            area[x1, i]++;
                        }
                    }
                    else
                    {
                        for (var i = y2; i <= y1; i++)
                        {
                            area[x1, i]++;
                        }
                    }
                }

                if (y1 == y2)
                {
                    if (x1 < x2)
                    {
                        for (var i = x1; i <= x2; i++)
                        {
                            area[i, y1]++;
                        }
                    }
                    else
                    {
                        for (var i = x2; i <= x1; i++)
                        {
                            area[i, y1]++;
                        }
                    }
                }
            }


            var count = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //Console.Write(area[j,i] + " ");
                    if (area[i, j] > 1) count++;
                }

                //Console.WriteLine();
            }

            Console.WriteLine(count);
        }

        public override void PartTwo()
        {
            var size = 1000;
            var area = new int[size, size];
            foreach (var (x1, y1, x2, y2) in _input)
            {
                //horizontal
                if (x1 == x2)
                {
                    if (y1 < y2)
                    {
                        for (var i = y1; i <= y2; i++)
                        {
                            area[x1, i]++;
                        }
                    }
                    else
                    {
                        for (var i = y2; i <= y1; i++)
                        {
                            area[x1, i]++;
                        }
                    }
                }
                else
                {
                    //vertical
                    if (y1 == y2)
                    {
                        if (x1 < x2)
                        {
                            for (var i = x1; i <= x2; i++)
                            {
                                area[i, y1]++;
                            }
                        }
                        else
                        {
                            for (var i = x2; i <= x1; i++)
                            {
                                area[i, y1]++;
                            }
                        }
                    }
                    else // diagonal
                    {
                        if (x1 < x2 && y1 < y2)
                        {
                            for (var i = 0; i <= x2 - x1; i++)
                            {
                                area[x1 + i, y1 + i]++;
                            }
                        }

                        if (x1 < x2 && y2 < y1)
                        {
                            for (var i = 0; i <= x2 - x1; i++)
                            {
                                area[x1 + i, y1 - i]++;
                            }
                        }

                        if (x2 < x1 && y1 < y2)
                        {
                            for (var i = 0; i <= x1 - x2; i++)
                            {
                                area[x1 - i, y1 + i]++;
                            }
                        }

                        if (x2 < x1 && y2 < y1)
                        {
                            for (var i = 0; i <= x1 - x2; i++)
                            {
                                area[x1 - i, y1 - i]++;
                            }
                        }
                    }
                }
            }


            var count = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //Console.Write(area[j,i] + " ");
                    if (area[i, j] > 1) count++;
                }

                //Console.WriteLine();
            }

            Console.WriteLine(count);
        }

        private static Tuple<int, int, int, int> Parser(GroupCollection groupCollection)
        {
            return new Tuple<int, int, int, int>(int.Parse(groupCollection[1].Value)
                , int.Parse(groupCollection[2].Value)
                , int.Parse(groupCollection[3].Value),
                int.Parse(groupCollection[4].Value));
        }
    }
}