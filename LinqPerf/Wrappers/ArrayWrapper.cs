using System;

namespace LinqPerf.Wrappers
{
    internal sealed class ArrayWrapper : IAddTest
    {
        private int[] array;

        public ArrayWrapper()
        {
            array = new int[0];
        }

        public string Name { get; } = "Array";

        public void AddOne(int value)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = value;
        }

        public void Warmup()
        {
            var tempArray = new int[3];
            Array.Resize(ref tempArray, 4);
            tempArray[tempArray.Length - 1] = 3;
        }
    }
}
