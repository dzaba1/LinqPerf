using System;
using System.Collections.Generic;
using System.Diagnostics;

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
    }
}
