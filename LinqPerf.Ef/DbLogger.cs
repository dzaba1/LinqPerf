using System;

namespace LinqPerf.Ef
{
    public sealed class DbLogger
    {
        public bool LoggingEnabled { get; set; }

        public void Log(string log)
        {
            if (LoggingEnabled && !string.IsNullOrWhiteSpace(log))
            {
                Console.WriteLine(log);
            }
        }
    }
}
