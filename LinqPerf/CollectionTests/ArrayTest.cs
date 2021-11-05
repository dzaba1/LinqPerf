using System;

namespace LinqPerf.CollectionTests
{
    internal sealed class ArrayTest : IAddTest
    {
        private int[] array;

        public ArrayTest(int initCount)
        {
            array = new int[initCount];
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
