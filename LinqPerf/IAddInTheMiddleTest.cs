namespace LinqPerf
{
    public interface IAddInTheMiddleTest : ITest
    {
        void AddAtPosition(int value, int index);
        void AddFirst(int value);
    }
}
