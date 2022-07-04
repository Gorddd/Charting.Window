using Charting.Window.Core;
using Charting.Window.Core.Graph;
using OxyPlot.Series;

namespace Charting.Window;

public class GraphBuilder
{
    private GraphOptionsBase graphOptions = new GraphOptions();

    public void UseFunctionSeries(FunctionSeries functionSeries) => graphOptions.functionSeries = functionSeries;
    public void SetFunction(Func<double, double> func) => graphOptions.func = func;
    public void SetBorders(double x0, double x1)
    {
        graphOptions.X0 = x0; graphOptions.X1 = x1;
    }
    public void SetDx(double dx) => graphOptions.Dx = dx;
    public void SetTitle(string name) => graphOptions.Name = name;

    public ISeriesItemCreator Build() => graphOptions;
}

