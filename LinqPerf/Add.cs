using LinqPerf.Wrappers;

namespace LinqPerf
{
    public static class Add
    {
        public static void AddTest()
        {
            var tests = new IAddTest[]
            {
                new ListWrapper(),
                new ArrayWrapper(),
                new LinkedListWrapper(),
                new HashSetWrapper()
            };

            Utils.TestTemplate(tests, 100000, (t, i) => t.AddOne(i));
        }

        public static void AddFirstTest()
        {
            var tests = new IAddInTheMiddleTest[]
            {
                new ListWrapper(),
                new LinkedListWrapper()
            };

            Utils.TestTemplate(tests, 100000, (t, i) => t.AddFirst(i));
        }

        public static void AddInTheMiddleTest()
        {
            var tests = new IAddInTheMiddleTest[]
            {
                new ListWrapper(),
                new LinkedListWrapper()
            };

            Utils.TestTemplate(tests, 60000, (t, i) => t.AddAtPosition(i, i / 2));
        }
    }
}
