using System.Collections.Generic;

namespace LinqPerf.CollectionTests
{
    internal sealed class ListTest : IAddTest, IAddInTheMiddleTest
    {
        private readonly List<int> list;

        public ListTest(int initCount)
        {
            list = new List<int>(initCount);
        }

        public string Name { get; } = "List";

        public void AddAtPosition(int value, int index)
        {
            list.Insert(index, value);
        }

        public void AddFirst(int value)
        {
            list.Insert(0, value);
        }

        public void AddOne(int value)
        {
            list.Add(value);
        }

        public void Warmup()
        {
            var tempList = new List<int>(3);
            tempList.Add(4);
            tempList.Insert(0, 2);
        }
    }
}
