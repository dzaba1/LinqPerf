using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPerf.Wrappers
{
    internal sealed class ArrayWrapper : IAddTest, IContainsTest
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

        public void AddOne(int value)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = value;
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
        }
    }
}
