using System.Collections.Generic;

namespace LinqPerf.CollectionTests
{
    internal sealed class LinkedListTest : IAddTest, IAddInTheMiddleTest
    {
        private readonly LinkedList<int> list = new LinkedList<int>();

        public string Name { get; } = "LinkedList";

        public void AddAtPosition(int value, int index)
        {
            var currentIndex = 0;
            var currentNode = list.First;
            while (currentIndex < index)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }

            if (currentNode == null)
            {
                list.AddFirst(value);
            }
            else
            {
                list.AddBefore(currentNode, value);
            }
        }

        public void AddFirst(int value)
        {
            list.AddFirst(value);
        }

        public void AddOne(int value)
        {
            list.AddLast(value);
        }

        public void Warmup()
        {
            var tempList = new LinkedList<int>();
            tempList.AddLast(1);
            tempList.AddFirst(2);
            tempList.AddAfter(tempList.First, 3);
        }
    }
}
