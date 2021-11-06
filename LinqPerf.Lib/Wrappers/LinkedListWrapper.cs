using System.Collections.Generic;

namespace LinqPerf.Lib.Wrappers
{
    internal sealed class LinkedListWrapper : IAddTest, IAddInTheMiddleTest, IContainsTest
    {
        private readonly LinkedList<int> list;

        public LinkedListWrapper()
        {
            list = new LinkedList<int>();
        }

        public LinkedListWrapper(IEnumerable<int> init)
        {
            list = new LinkedList<int>(init);
        }

        public string Name { get; } = "LinkedList";

        private LinkedListNode<int> FindNodeByIndex(int index)
        {
            var currentIndex = 0;
            var currentNode = list.First;
            while (currentIndex < index)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }

            return currentNode;
        }

        public void AddAtPosition(int value, int index)
        {
            var node = FindNodeByIndex(index);

            if (node == null)
            {
                list.AddFirst(value);
            }
            else
            {
                list.AddBefore(node, value);
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

        public bool Contains(int value)
        {
            return list.Find(value) != null;
        }

        public void Warmup()
        {
            var tempList = new LinkedList<int>();
            tempList.AddLast(1);
            tempList.AddFirst(2);
            tempList.AddAfter(tempList.First, 3);
            tempList.Find(2);
        }
    }
}
