using System.Collections.Generic;

namespace LinqPerf.Wrappers
{
    internal sealed class HashSetWrapper : IAddTest
    {
        private readonly HashSet<int> set;

        public HashSetWrapper()
        {
            set = new HashSet<int>();
        }

        public string Name { get; } = "HashSet";

        public void AddOne(int value)
        {
            set.Add(value);
        }

        public void Warmup()
        {
            var tempSet = new HashSet<int>();
            tempSet.Add(2);
        }
    }
}
