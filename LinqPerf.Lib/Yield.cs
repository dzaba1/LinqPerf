using System;
using System.Linq;

namespace LinqPerf.Lib
{
    public static class Yield
    {
        public static void YieldTest()
        {
            Console.WriteLine("Before invoking the stream");
            var stream = Utils.StreamOfRandoms(100, true);
            Console.WriteLine("After making the stream");

            var processed = stream
                .Where(i =>
                {
                    Console.WriteLine($"Processing Where of {i}");
                    return i > 0;
                })
                .Select(i =>
                {
                    Console.WriteLine($"Processing Select of {i}");
                    return i + 10;
                });

            Console.WriteLine("After processing");

            foreach (var item in processed)
            {
                Console.WriteLine($"Finally got {item}");
            }
        }
    }
}
