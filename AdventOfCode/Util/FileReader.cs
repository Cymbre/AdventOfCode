using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Util
{
    public static class FileReader
    {
        public static List<string> ReadFileToStringList(string path)
        {
            return File.ReadAllLines(path).ToList();
        }

        public static List<int> ReadFileToIntList(string path)
        {
            return File.ReadAllLines(path).Select(int.Parse).ToList();
        }


        public static List<Tuple<string, int>> ReadFileToStringIntTupleList(string path)
        {
            var input = File.ReadAllLines(path).ToList();
            var tupleList = new List<Tuple<string, int>>();
            foreach (var row in input)
            {
                var parts = row.Split(" ");
                tupleList.Add(new Tuple<string, int>(parts[0], int.Parse(parts[1])));
            }

            return tupleList;
        }


        public static List<T> ReadFileToObjectListWithRegex<T>(string path, string pattern,
            Func<GroupCollection, T> parser)
        {
            var input = File.ReadAllLines(path).ToList();

            var output = new List<T>();
            foreach (var row in input)
            {
                var match = Regex.Match(row, pattern);
                output.Add(parser.Invoke(match.Groups));
            }

            return output;
        }
    }
}