using OxyPlot.Series;

namespace Charting.Window.Core.Graph;

class GraphOptions : GraphOptionsBase
{
    public override Series CreateSeries()
    {
        FunctionSeries series = new FunctionSeries();

        if (func == null && Points == null)
            throw new ArgumentNullException("Func hasn't defined");

        if (func != null)
            series = new FunctionSeries(func, X0, X1, Dx);
        if (Points != null)
            foreach (var point in Points)
                series.Points.Add(point.ToDataPoint());

        series.Title = Name;
        series.InterpolationAlgorithm = InterpolationAlgorithm;

        return series;
    }
}

