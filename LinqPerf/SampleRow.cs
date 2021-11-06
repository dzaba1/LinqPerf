using System;
using System.Collections.Generic;
using System.Dynamic;

namespace LinqPerf
{
    public sealed class SampleRow : DynamicObject
    {
        private Dictionary<string, TimeSpan> values = new Dictionary<string, TimeSpan>();

        public SampleRow(int iteration, int count)
        {
            Iteration = iteration;
            Count = count;
        }

        public int Iteration { get; }

        public int Count { get; }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return values.Keys;
        }

        public override bool TryDeleteMember(DeleteMemberBinder binder)
        {
            return values.Remove(binder.Name);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (values.TryGetValue(binder.Name, out var value))
            {
                result = value;
                return true;
            }

            result = null;
            return false;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            values[binder.Name] = (TimeSpan)value;
            return true;
        }

        public TimeSpan this[string name]
        {
            get => values[name];
            set => values[name] = value;
        }
    }
}
