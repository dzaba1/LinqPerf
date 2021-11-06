using LinqPerf.Chart;
using LinqPerf.Lib;
using System;

namespace LinqPerf
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var samples = Contains.ContainsTest();
            Show.Samples(samples);
        }
    }
}
