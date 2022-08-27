using OxyPlot;
using OxyPlot.Series;

namespace Charting.Window.Core.Graph;

abstract class GraphOptionsBase : ISeriesItemCreator
{
    public string? Name { get; set; } = null!;
    public Queue<(double x, double y)> Points { get; set; } = null!;
    public IInterpolationAlgorithm InterpolationAlgorithm { get; set; } = null!;
    public Func<double, double> func { get; set; } = null!;
    public double X0 { get; set; } = -1000;
    public double X1 { get; set; } = 1000;
    public double Dx { get; set; } = 0.01;

    public Color GraphColor { get; set; }

    public abstract Series CreateSeries();
    public abstract void UpdateSeries(Series series);
}

