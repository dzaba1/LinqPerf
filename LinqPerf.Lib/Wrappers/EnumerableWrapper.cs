using System.Collections.Generic;
using System.Linq;

namespace LinqPerf.Lib.Wrappers
{
    internal sealed class EnumerableWrapper : IContainsTest
    {
        private readonly IEnumerable<int> enumerable;

        public EnumerableWrapper(IEnumerable<int> init)
        {
            enumerable = init;
        }

        public string Name { get; } = "Enumerable";

        public bool Contains(int value)
        {
            return enumerable.Contains(value);
        }

        public void Warmup()
        {
            var temp = Enumerable.Range(0, 10);
            temp.Contains(1);
        }
    }
}
