using System;
using System.Collections.Generic;

namespace LinqPerf
{
    internal sealed class Samples
    {
        private readonly Dictionary<string, int> columns = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        private readonly List<TimeSpan[]> values;

        public Samples(int initCount, IEnumerable<ITest> tests)
        {
            var current = 0;
            foreach (var test in tests)
            {
                columns.Add(test.Name, current);
                current++;
            }

            values = new List<TimeSpan[]>(initCount);
        }

        public void AddValue(int iteration, ITest test, TimeSpan value)
        {
            var columnIndex = columns[test.Name];
            
            while (iteration >= values.Count)
            {
                var newRow = new TimeSpan[columns.Count];
                values.Add(newRow);
            }

            var row = values[iteration];
            row[columnIndex] = value;
        }
    }
}
