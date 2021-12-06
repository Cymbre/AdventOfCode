using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Util;

namespace AdventOfCode.Days
{
    public class Day06 : Day
    {
        private List<int> _input;

        public Day06() : base()
        {
            _path = BasePath + "day06.txt";
            _input = FileReader.ReadFileToStringList(_path)[0]
                .Split(",")
                .Select(int.Parse)
                .ToList();
        }

        public override void PartOne()
        {
            var input = new List<int>(_input);
            const int dayCount = 35;
            for (int i = 0; i < dayCount; i++)
            {
                var fishThatDay = input.Count;
                //Console.Write(i + ": ");
                for (int fish = 0; fish < fishThatDay; fish++)
                {
                    //Console.Write(input[fish]);
                    if (input[fish] > 0) input[fish]--;
                    else
                    {
                        input[fish] = 6;
                        input.Add(8);
                    }
                }

                //Console.WriteLine();
            }

            Console.WriteLine(input.Count);
            Console.WriteLine("----");
        }

        public override void PartTwo()
        {
            ulong sum = 0;
            var days = 256;
            var fishes = new Dictionary<int, ulong>();
            foreach (var fish in _input)
            {
                Console.WriteLine(fish);
                if (fishes.ContainsKey(fish))
                {
                    sum += fishes[fish];
                }
                else
                {
                    var calc = calculateFishesRecursive(days - fish);
                    sum += calc;
                    fishes.Add(fish, calc);
                }

                //Console.WriteLine(fish + " " + calc + " " + sum);
                Console.WriteLine("-----------");
            }

            Console.WriteLine(sum);
        }


        private ulong calculateFishesRecursive(int days)
        {
            if (days < 1) return 1;
            if (days < 8) return 2;
            if (days < 10) return 3;
            if (days < 15) return 4;
            //Console.WriteLine(days + ": " + (days -7) + " - " + (days - 2 -7 ));
            return calculateFishesRecursive(days - 7) + calculateFishesRecursive(days - 2 - 7);
        }
    }
}