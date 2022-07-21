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
            while (Points.Count > 0)
            {
                var point = Points.Dequeue();
                series.Points.Add(new OxyPlot.DataPoint(point.x, point.y));
            }

        series.Title = Name;
        series.InterpolationAlgorithm = InterpolationAlgorithm;

        return series;
    }

    public override void UpdateSeries(Series series)
    {
        var funSeries = series as FunctionSeries ?? 
            throw new ArgumentNullException("the Series param in UpdateSeries() is not FunctionSeries");

        while (Points.Count > 0)
        {
            var point = Points.Dequeue();
            funSeries.Points.Add(new OxyPlot.DataPoint(point.x, point.y));
        }
    }
}