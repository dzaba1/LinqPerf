using LinqPerf.Lib.Wrappers;
using System.Linq;

namespace LinqPerf.Lib
{
    public sealed class Contains
    {
        public static void ContainsAllValues()
        {
            var initCount = 100000;
            var enumerable = Enumerable.Range(0, initCount);

            var tests = new IContainsTest[]
            {
                new ListWrapper(enumerable),
                new ArrayWrapper(enumerable),
                new LinkedListWrapper(enumerable),
                new HashSetWrapper(enumerable),
                new EnumerableWrapper(enumerable)
            };

            Utils.TestTemplate(tests, initCount, initCount, (t, i) => t.Contains(i));
        }
    }
}
