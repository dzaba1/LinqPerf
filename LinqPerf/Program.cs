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
            var samples = Add.AddTest();
            Show.Samples(samples);
        }
    }
}
