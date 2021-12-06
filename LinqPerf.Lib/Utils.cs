using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LinqPerf.Lib
{
    public static class Utils
    {
        public static TimeSpan Measure(Action action, string name)
        {
            var perfWatch = Stopwatch.StartNew();
            action();
            perfWatch.Stop();
            var elapsed = perfWatch.Elapsed;
            ConsoleEx.WriteLine($"The {name} took {elapsed}", ConsoleColor.Yellow);
            return elapsed;
        }

        public static void Warmup(this IEnumerable<ITest> tests)
        {
            foreach (var test in tests)
            {
                for (int i = 0; i < 3; i++)
                {
                    test.Warmup();
                }
            }
        }

        public static Samples TestTemplate<T>(IEnumerable<T> tests, int initCount, int iterations, Action<T, int> testAction)
            where T : ITest
        {
            return TestTemplate(tests, initCount, iterations, false, testAction);
        }

        public static Samples TestTemplate<T>(IEnumerable<T> tests, int initCount, int iterations, bool addingValues, Action<T, int> testAction)
            where T : ITest
        {
            tests.Cast<ITest>().Warmup();

            var samples = new Samples(iterations, initCount, tests.Select(t => t.Name));
            samples.AddingValues = addingValues;

            for (int i = 0; i < iterations; i++)
            {
                foreach (var test in tests)
                {
                    var value = Measure(() => testAction(test, i), $"{test.Name} ({i})");
                    samples.AddValue(i, test.Name, value);
                }
            }

            return samples;
        }
    }
}
