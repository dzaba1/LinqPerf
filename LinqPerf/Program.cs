using LinqPerf.CollectionTests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPerf
{
    class Program
    {
        static void Main(string[] args)
        {
            AddInTheMiddleTest();
        }

        private static Samples TestPattern<T>(IEnumerable<T> tests, int iterations, Action<T, int> testAction)
            where T : ITest
        {
            var testsCast = tests.Cast<ITest>();
            testsCast.Warmup();

            var samples = new Samples(iterations, testsCast);

            for (int i = 0; i < iterations; i++)
            {
                foreach (var test in tests)
                {
                    var value = Utils.Measure(() => testAction(test, i), $"{test.Name} ({i})");
                    samples.AddValue(i, test, value);
                }
            }

            return samples;
        }

        private static void AddTest()
        {
            var tests = new IAddTest[]
            {
                new ListTest(0),
                new ArrayTest(0),
                new LinkedListTest()
            };

            TestPattern(tests, 100000, (t, i) => t.AddOne(i));
        }

        private static void AddFirstTest()
        {
            var tests = new IAddInTheMiddleTest[]
            {
                new ListTest(0),
                new LinkedListTest()
            };

            TestPattern(tests, 100000, (t, i) => t.AddFirst(i));
        }

        private static void AddInTheMiddleTest()
        {
            var tests = new IAddInTheMiddleTest[]
            {
                new ListTest(0),
                new LinkedListTest()
            };

            TestPattern(tests, 60000, (t, i) => t.AddAtPosition(i, i / 2));
        }
    }
}
