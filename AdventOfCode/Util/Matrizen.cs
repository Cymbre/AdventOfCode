using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Util
{
    public static class Matrizen
    {
        public static List<List<T>> Transpose<T>(this List<List<T>> matrix)
        {
            // 23
            // 34
            // 45    

            return matrix[0].Select((x, index) => matrix.Select(y => y[index]).ToList()).ToList();
        }
    }
}