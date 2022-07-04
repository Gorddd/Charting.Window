using OxyPlot.Series;

namespace Charting.Window.Core.Graph;

class GraphOptions : GraphOptionsBase
{
    public override Series CreateSeries()
    {
        FunctionSeries series;

        if (functionSeries != null)
            series = functionSeries;
        else if (func == null)
            throw new ArgumentNullException("Func hasn't defined");
        else
            series = new FunctionSeries(func, X0, X1, Dx, Name);

        return series;
    }
}

