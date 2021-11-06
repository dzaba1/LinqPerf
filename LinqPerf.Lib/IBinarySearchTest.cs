namespace LinqPerf.Lib
{
    public interface IBinarySearchTest : ITest
    {
        bool BinaryContains(int value);
        string BinaryTestName { get; }
    }
}
