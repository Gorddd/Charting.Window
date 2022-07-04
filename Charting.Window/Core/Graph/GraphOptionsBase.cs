using OxyPlot.Series;

namespace Charting.Window.Core.Graph;

abstract class GraphOptionsBase : ISeriesItemCreator
{
    public FunctionSeries functionSeries { get; set; } = null!;
    public string? Name { get; set; } = null!;
    public Func<double, double> func { get; set; } = null!;
    public double X0 { get; set; } = -1000;
    public double X1 { get; set; } = 1000;
    public double Dx { get; set; } = 0.01;

    public abstract Series CreateSeries();
}

