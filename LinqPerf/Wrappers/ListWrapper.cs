using System.Collections.Generic;

namespace LinqPerf.Wrappers
{
    internal sealed class ListWrapper : IAddTest, IAddInTheMiddleTest, IContainsTest
    {
        private readonly List<int> list;

        public ListWrapper()
        {
            list = new List<int>();
        }

        public ListWrapper(IEnumerable<int> init)
        {
            list = new List<int>(init);
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

        public bool Contains(int value)
        {
            return list.Contains(value);
        }

        public void Warmup()
        {
            var tempList = new List<int>(3);
            tempList.Add(4);
            tempList.Insert(0, 2);
        }
    }
}
