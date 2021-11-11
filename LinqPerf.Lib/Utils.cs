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

        public static IEnumerable<int> StreamOfRandoms(int count, bool debugPrint = false)
        {
            if (debugPrint)
            {
                Console.WriteLine("Before creating random");
            }

            var random = new Random();

            if (debugPrint)
            {
                Console.WriteLine("Before making the loop");
            }

            for (int i = 0; i < count; i++)
            {
                if (debugPrint)
                {
                    Console.WriteLine("Before Next");
                }

                var value = random.Next();

                if (debugPrint)
                {
                    Console.WriteLine($"Before yield {value}");
                }

                yield return value;

                if (debugPrint)
                {
                    Console.WriteLine($"After yield {value}");
                }
            }

            if (debugPrint)
            {
                Console.WriteLine("After loop");
            }
        }
    }
}
