namespace LinqPerf
{
    public interface ITest
    {
        void Warmup();
        string Name { get; }
    }
}
