using System;
using System.Linq;

namespace LinqPerf.Lib
{
    public static class Yield
    {
        public static void YieldTest()
        {
            ConsoleEx.WriteLine("Before invoking the stream", ConsoleColor.White);
            var stream = EnumerableStream.OfRandoms(100, true);
            ConsoleEx.WriteLine("After making the stream", ConsoleColor.White);

            var processed = stream
                .Where(i =>
                {
                    ConsoleEx.WriteLine($"Processing Where of {i}", ConsoleColor.White);
                    return i > 0;
                })
                .Select(i =>
                {
                    ConsoleEx.WriteLine($"Processing Select of {i}", ConsoleColor.White);
                    return i + 10;
                });

            ConsoleEx.WriteLine("After processing", ConsoleColor.White);

            foreach (var item in processed)
            {
                ConsoleEx.WriteLine($"Finally got {item}", ConsoleColor.White);
            }
        }
    }
}
