using LinqPerf.Lib.Wrappers;

namespace LinqPerf.Lib
{
    public static class Add
    {
        public static Samples AddTest()
        {
            var tests = new IAddTest[]
            {
                new ListWrapper(),
                new ArrayWrapper(),
                new LinkedListWrapper(),
                new HashSetWrapper()
            };

            return Utils.TestTemplate(tests, 0, 100000, true, (t, i) => t.AddOne(i));
        }

        public static Samples AddFirstTest()
        {
            var tests = new IAddInTheMiddleTest[]
            {
                new ListWrapper(),
                new LinkedListWrapper()
            };

            return Utils.TestTemplate(tests, 0, 100000, true, (t, i) => t.AddFirst(i));
        }

        public static Samples AddInTheMiddleTest()
        {
            var tests = new IAddInTheMiddleTest[]
            {
                new ListWrapper(),
                new LinkedListWrapper()
            };

            return Utils.TestTemplate(tests, 0, 60000, true, (t, i) => t.AddAtPosition(i, i / 2));
        }
    }
}
