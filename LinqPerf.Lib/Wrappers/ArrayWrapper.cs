using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPerf.Lib.Wrappers
{
    internal sealed class ArrayWrapper : IAddTest, IContainsTest, IBinarySearchTest
    {
        private int[] array;

        public ArrayWrapper()
        {
            array = new int[0];
        }

        public ArrayWrapper(IEnumerable<int> init)
        {
            array = init.ToArray();
        }

        public string Name { get; } = "Array";

        public string BinaryTestName { get; } = "ArrayBinarySearch";

        public void AddOne(int value)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = value;
        }

        public bool BinaryContains(int value)
        {
            return Array.BinarySearch(array, value) >= 0;
        }

        public bool Contains(int value)
        {
            return Array.IndexOf(array, value) >= 0;
        }

        public void Warmup()
        {
            var tempArray = new int[3];
            Array.Resize(ref tempArray, 4);
            tempArray[tempArray.Length - 1] = 3;
            Array.IndexOf(tempArray, 2);
            Array.BinarySearch(tempArray, 2);
        }
    }
}
