using Charting.Window.Core;
using Charting.Window.Core.Graph;
using OxyPlot.Series;

namespace Charting.Window;

public class GraphBuilder
{
    private GraphOptionsBase graphOptions = new GraphOptions();

    public GraphBuilder UseFunctionSeries(FunctionSeries functionSeries)
    {
        graphOptions.functionSeries = functionSeries;
        return this;
    }
    public GraphBuilder SetFunction(Func<double, double> func)
    {
        graphOptions.func = func;
        return this;
    }
    public GraphBuilder SetRange(double x0, double x1)
    {
        graphOptions.X0 = x0; graphOptions.X1 = x1;
        return this;
    }
    public GraphBuilder SetDx(double dx) 
    {
        graphOptions.Dx = dx;
        return this;
    }
    public GraphBuilder SetName(string name) 
    {
        graphOptions.Name = name;
        return this;
    }

    public ISeriesItemCreator Build() => graphOptions;
}

