using System;
using System.Collections.Generic;

namespace AdventOfCode.Util
{
    public static class Util
    {
        public static T FindMedianInList<T>(List<T> list)
        {
            var res = new List<T>(list);
            res.Sort();
            return res[res.Count / 2];
        }

        public static int Factorial(int i)
        {
            Console.WriteLine(i);
            if (i <= 1) return 1;
            return i * Factorial(i - 1);
        }

        public static int TriangularNumber(int i)
        {
            return i * (i + 1) / 2;
        }
    }
}