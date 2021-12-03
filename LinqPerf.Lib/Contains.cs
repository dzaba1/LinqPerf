using LinqPerf.Lib.Wrappers;
using System.Linq;

namespace LinqPerf.Lib
{
    public sealed class Contains
    {
        public static Samples ContainsTest()
        {
            var initCount = 100000;
            var enumerable = Enumerable.Range(0, initCount);

            var tests = new IContainsTest[]
            {
                new ListWrapper(enumerable),
                new ArrayWrapper(enumerable),
                new LinkedListWrapper(enumerable),
                new EnumerableWrapper(enumerable),
                new HashSetWrapper(enumerable),
                new DictionaryWrapper(enumerable)
            };

            tests.Warmup();

            var columns = tests
                .Select(t => t.Name)
                .Concat(tests.OfType<IBinarySearchTest>().Select(t => t.BinaryTestName));
            var samples = new Samples(initCount, initCount, columns);

            for (int i = 0; i < initCount; i++)
            {
                foreach (var test in tests)
                {
                    var value = Utils.Measure(() => test.Contains(i), $"{test.Name} ({i})");
                    samples.AddValue(i, test.Name, value);

                    var binaryTest = test as IBinarySearchTest;
                    if (binaryTest != null)
                    {
                        value = Utils.Measure(() => binaryTest.BinaryContains(i), $"{binaryTest.BinaryTestName} ({i})");
                        samples.AddValue(i, binaryTest.BinaryTestName, value);
                    }
                }
            }

            return samples;
        }
    }
}
