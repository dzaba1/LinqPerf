namespace LinqPerf.Lib
{
    public interface ITest
    {
        void Warmup();
        string Name { get; }
    }
}
