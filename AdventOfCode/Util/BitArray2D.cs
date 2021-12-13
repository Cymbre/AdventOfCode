using System;
using System.Collections;

namespace AdventOfCode.Util
{
    public sealed class BitArray2D
    {
        private BitArray _array;
        private int _dimension1;
        private int _dimension2;

        public BitArray2D(int dimension1, int dimension2)
        {
            _dimension1 = dimension1 > 0
                ? dimension1
                : throw new ArgumentOutOfRangeException(nameof(dimension1), dimension1, string.Empty);
            _dimension2 = dimension2 > 0
                ? dimension2
                : throw new ArgumentOutOfRangeException(nameof(dimension2), dimension2, string.Empty);
            _array = new BitArray(dimension1 * dimension2);
        }

        public bool this[int x, int y]
        {
            get { return Get(x, y); }
            set { Set(x, y, value); }
        }

        public int Dimension1
        {
            get => _dimension1;
        }

        public int Dimension2
        {
            get => _dimension2;
        }

        public bool Get(int x, int y)
        {
            CheckBounds(x, y);
            return _array[y * _dimension1 + x];
        }

        public bool Set(int x, int y, bool val)
        {
            CheckBounds(x, y);
            return _array[y * _dimension1 + x] = val;
        }

        private void CheckBounds(int x, int y)
        {
            if (x < 0 || x >= _dimension1)
            {
                throw new IndexOutOfRangeException();
            }

            if (y < 0 || y >= _dimension2)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void printArray()
        {
            for (int i = 0; i < Dimension2; i++)
            {
                for (int j = 0; j < Dimension1; j++)
                {
                    //if((j+1)%5 == 0 && j > 0) Console.Write(" ");
                    //else
                    Console.Write(_array[i * _dimension1 + j] ? "#" : " ");
                }

                Console.WriteLine();
            }
        }
    }
}