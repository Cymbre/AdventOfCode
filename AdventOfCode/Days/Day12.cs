using System;
using System.Collections.Generic;
using AdventOfCode.Util;

namespace AdventOfCode.Days
{
    public class Day12 : Day
    {
        private Dictionary<string, List<string>> _input;

        public Day12() : base()
        {
            _path = BasePath + "day12.txt";
            var input = FileReader.ReadFileToStringList(_path);
            _input = new Dictionary<string, List<string>>();

            foreach (var row in input)
            {
                var parts = row.Split("-");

                if (parts[1] != ("start"))
                {
                    if (_input.ContainsKey(parts[0]))
                    {
                        _input[parts[0]].Add(parts[1]);
                    }
                    else
                    {
                        var list = new List<string>();
                        list.Add(parts[1]);
                        _input.Add(parts[0], list);
                    }
                }

                //reverse
                if (parts[0] != "start")
                {
                    if (_input.ContainsKey(parts[1]))
                    {
                        _input[parts[1]].Add(parts[0]);
                    }
                    else
                    {
                        var list = new List<string>();
                        list.Add(parts[0]);
                        _input.Add(parts[1], list);
                    }
                }
            }
        }

        public override void PartOne()
        {
            var start = _input["start"];
            var pathSum = 0;
            foreach (var s in start)
            {
                Console.WriteLine("start" + " -> " + s);
                HashSet<string> smallCaves = new HashSet<string>();
                if (!IsAllUpper(s))
                {
                    smallCaves.Add(s);
                }

                pathSum += FollowPath(smallCaves, s);
                Console.WriteLine(pathSum);
            }

            Console.WriteLine(pathSum);
        }

        private int FollowPath(HashSet<string> smallCavesVisited, string nextCave)
        {
            var pathSum = 0;
            foreach (var cave in _input[nextCave])
            {
                //Console.Write(nextCave + " -> " + cave);
                if (cave == "end")
                {
                    pathSum++;
                    //Console.WriteLine();
                    foreach (var smallCave in smallCavesVisited)
                    {
                        //Console.Write(smallCave + " ");
                    }

                    //Console.WriteLine();
                    continue;
                }

                var smallCaves = new HashSet<string>(smallCavesVisited);
                if (!IsAllUpper(cave))
                {
                    if (!smallCaves.Add(cave))
                    {
                        //Console.WriteLine(" -> dead");
                        continue;
                    }
                }

                //Console.WriteLine();
                pathSum += FollowPath(smallCaves, cave);
            }

            return pathSum;
        }

        private int FollowPath(HashSet<string> smallCavesVisited, bool extra, string nextCave)
        {
            var pathSum = 0;
            foreach (var cave in _input[nextCave])
            {
                var cExtra = extra;
                // Console.Write(nextCave + " -> " + cave);
                if (cave == "end")
                {
                    pathSum++;
                    // Console.WriteLine();
                    foreach (var smallCave in smallCavesVisited)
                    {
                        // Console.Write(smallCave + " ");
                    }

                    // Console.WriteLine();
                    continue;
                }

                var smallCaves = new HashSet<string>(smallCavesVisited);
                if (!IsAllUpper(cave))
                {
                    if (!smallCaves.Add(cave))
                    {
                        if (extra)
                        {
                            // Console.WriteLine(" -> dead");
                            continue;
                        }

                        //Console.WriteLine("extra: "+ cave);
                        cExtra = true;
                    }
                }

                //Console.WriteLine();
                pathSum += FollowPath(smallCaves, cExtra, cave);
            }

            return pathSum;
        }

        public override void PartTwo()
        {
            var start = _input["start"];
            var pathSum = 0;
            foreach (var s in start)
            {
                Console.WriteLine("start" + " -> " + s);
                HashSet<string> smallCaves = new HashSet<string>();
                if (!IsAllUpper(s))
                {
                    smallCaves.Add(s);
                }

                pathSum += FollowPath(smallCaves, false, s);
                Console.WriteLine(pathSum);
            }

            Console.WriteLine(pathSum);
        }

        private bool IsAllUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsUpper(input[i]))
                    return false;
            }

            return true;
        }
    }
}