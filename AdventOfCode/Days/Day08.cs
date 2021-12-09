using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Util;

namespace AdventOfCode.Days
{
    public class Day08 : Day
    {
        private List<List<string>> _input;

        public Day08() : base()
        {
            _path = BasePath + "day08.txt";
            _input = FileReader.ReadFileToStringList(_path)
                .Select(w => w.Split(" ")
                    .Where(value => value != @"|")
                    .Select(value => string.Concat(value.OrderBy(c => c)))
                    .ToList()
                ).ToList();
        }

        public override void PartOne()
        {
            var count = 0;
            foreach (var row in _input)
            {
                for (int i = 1; i <= 4; i++)
                {
                    var segment = row[^i];
                    if (segment.Length == 2 || segment.Length == 3 || segment.Length == 4 || segment.Length == 7)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        public override void PartTwo()
        {
            var sum = 0;
            foreach (var row in _input)
            {
                var map = new Dictionary<HashSet<char>, int>(HashSet<char>.CreateSetComparer());
                var digits = row.GetRange(0, 10).Select(s => s.ToCharArray().ToHashSet());

                var enumerable = digits.ToList();
                var one = enumerable.First(d => d.Count == 2);
                var four = enumerable.First(d => d.Count == 4);
                var seven = enumerable.First(d => d.Count == 3);
                var eight = enumerable.First(d => d.Count == 7);

                var segement5 = enumerable.Where(d => d.Count == 5);
                var segement6 = enumerable.Where(d => d.Count == 6);

                var enumerable1 = segement6.ToList();
                var nine = enumerable1.First(d => d.IsSupersetOf(four));
                var zero = enumerable1.First(d => d.IsSupersetOf(one) && !d.IsSupersetOf(nine));
                var six = enumerable1.First(d => !d.IsSupersetOf(zero) && !d.IsSupersetOf(nine));

                var enumerable2 = segement5.ToList();
                var three = enumerable2.First(d => d.IsSupersetOf(one));
                var five = enumerable2.First(d => six.IsSupersetOf(d) && !d.IsSupersetOf(three));
                var two = enumerable2.First(d => !d.IsSupersetOf(three) && !d.IsSupersetOf(five));

                map.Add(zero, 0);
                map.Add(one, 1);
                map.Add(two, 2);
                map.Add(three, 3);
                map.Add(four, 4);
                map.Add(five, 5);
                map.Add(six, 6);
                map.Add(seven, 7);
                map.Add(eight, 8);
                map.Add(nine, 9);

                var output = row.GetRange(10, 4).Select(s => s.ToCharArray().ToHashSet());
                sum += output.Select((d, index) =>
                    map[d] * (int) Math.Pow(10, 3 - index)).Sum();
            }

            Console.WriteLine(sum);
        }
    }
}