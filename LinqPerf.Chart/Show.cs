using LinqPerf.Lib;
using System.Windows;

namespace LinqPerf.Chart
{
    public static class Show
    {
        public static void Samples(Samples samples)
        {
            var vm = new SamplesViewModel();
            vm.SetSamples(samples);

            var window = new MainWindow();
            window.DataContext = vm;

            var app = new Application();
            app.Run(window);
        }
    }
}
