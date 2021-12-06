using System;
using System.Collections.Generic;

namespace LinqPerf.Lib
{
    public static class EnumerableStream
    {
        public static IEnumerable<int> OfRandoms(int count, bool debugPrint = false)
        {
            if (debugPrint)
            {
                ConsoleEx.WriteLine("Before creating random", ConsoleColor.Cyan);
            }

            var random = new Random();

            if (debugPrint)
            {
                ConsoleEx.WriteLine("Before making the loop", ConsoleColor.Cyan);
            }

            for (int i = 0; i < count; i++)
            {
                if (debugPrint)
                {
                    ConsoleEx.WriteLine("Before Next", ConsoleColor.Cyan);
                }

                var value = random.Next();

                if (debugPrint)
                {
                    ConsoleEx.WriteLine($"Before yield {value}", ConsoleColor.Cyan);
                }

                yield return value;

                if (debugPrint)
                {
                    ConsoleEx.WriteLine($"After yield {value}", ConsoleColor.Cyan);
                }
            }

            if (debugPrint)
            {
                ConsoleEx.WriteLine("After loop", ConsoleColor.Cyan);
            }
        }
    }
}
