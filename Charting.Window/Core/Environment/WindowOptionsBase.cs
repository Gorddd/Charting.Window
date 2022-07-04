using OxyPlot;

namespace Charting.Window.Core.Environment;

abstract class WindowOptionsBase : IPlotModelCreator
{
    public abstract PlotModel CreatePlotModel();

    public string? Title { get; set; }
}
