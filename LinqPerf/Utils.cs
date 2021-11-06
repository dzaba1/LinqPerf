using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LinqPerf
{
    public static class Utils
    {
        public static TimeSpan Measure(Action action, string name)
        {
            var perfWatch = Stopwatch.StartNew();
            action();
            perfWatch.Stop();
            var elapsed = perfWatch.Elapsed;
            Console.WriteLine($"The {name} took {elapsed}");
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
            var testsCast = tests.Cast<ITest>();
            testsCast.Warmup();

            var samples = new Samples(iterations, initCount, testsCast);

            for (int i = 0; i < iterations; i++)
            {
                foreach (var test in tests)
                {
                    var value = Measure(() => testAction(test, i), $"{test.Name} ({i})");
                    samples.AddValue(i, test, value);
                }
            }

            return samples;
        }
    }
}
