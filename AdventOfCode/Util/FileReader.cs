using System.Collections.Generic;
using System.IO;
using System.Linq;

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
    }
}