using LinqPerf.Lib;
using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;
using System.Collections.Generic;
using System.ComponentModel;

namespace LinqPerf.Chart
{
    internal sealed class SamplesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void SetSamples(Samples samples)
        {
            var model = new PlotModel();
            model.Legends.Add(new Legend
            {
                LegendPlacement = LegendPlacement.Outside
            });

            var series = new Dictionary<string, LineSeries>();

            foreach (var row in samples.EnumerateRows())
            {
                foreach (var propName in row.GetDynamicMemberNames())
                {
                    if (!series.TryGetValue(propName, out var serie))
                    {
                        serie = new LineSeries
                        {
                            Title = propName
                        };
                        series.Add(propName, serie);
                    }

                    var value = row[propName];
                    serie.Points.Add(new DataPoint(row.Iteration, value.TotalMilliseconds));
                }
            }

            foreach (var serie in series.Values)
            {
                model.Series.Add(serie);
            }

            Model = model;
        }

        private PlotModel _model;
        public PlotModel Model
        {
            get => _model;
            set
            {
                _model = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Model)));
            }
        }
    }
}
