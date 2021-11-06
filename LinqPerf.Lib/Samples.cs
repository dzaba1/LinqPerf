using System;
using System.Collections.Generic;

namespace LinqPerf.Lib
{
    public sealed class Samples
    {
        private readonly Dictionary<string, int> columns = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        private readonly List<TimeSpan[]> values;
        private readonly int initCount;

        public Samples(int iterations, int initCount, IEnumerable<ITest> tests)
        {
            var current = 0;
            foreach (var test in tests)
            {
                columns.Add(test.Name, current);
                current++;
            }

            values = new List<TimeSpan[]>(iterations);
            this.initCount = initCount;
        }

        public bool AddingValues { get; set; }

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

        public IEnumerable<SampleRow> EnumerateRows()
        {
            for (int i = 0; i < values.Count; i++)
            {
                var value = values[i];
                var count = initCount;
                if (AddingValues)
                {
                    count = initCount + i;
                }
                var row = new SampleRow(i, count);

                foreach (var columnPair in columns)
                {
                    row[columnPair.Key] = value[columnPair.Value];
                }

                yield return row;
            }
        }


    }
}
