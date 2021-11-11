using System.Collections.Generic;
using System.Linq;

namespace LinqPerf.Lib.Wrappers
{
    internal sealed class DictionaryWrapper : IAddTest, IContainsTest
    {
        private readonly Dictionary<int, string> dict;

        public DictionaryWrapper()
        {
            dict = new Dictionary<int, string>();
        }

        public DictionaryWrapper(IEnumerable<int> init)
        {
            dict = init.ToDictionary(i => i, i => $"Value{i}");
        }

        public string Name { get; } = "Dictionary";

        public void AddOne(int value)
        {
            dict.Add(value, $"Value{value}");
        }

        public bool Contains(int value)
        {
            return dict.ContainsKey(value);
        }

        public void Warmup()
        {
            var temp = new Dictionary<int, string>();
            temp.Add(1, "1");
            temp.ContainsKey(1);
        }
    }
}
