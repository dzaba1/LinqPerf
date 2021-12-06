using System;

namespace LinqPerf.Lib
{
    public static class ConsoleEx
    {
        public static void WriteLine(string line, ConsoleColor color)
        {
            var prevColor = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = color;
                Console.WriteLine(line);
            }
            finally
            {
                Console.ForegroundColor = prevColor;
            }
        }
    }
}
