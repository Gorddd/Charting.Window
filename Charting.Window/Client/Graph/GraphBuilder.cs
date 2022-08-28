using Charting.Window.Core;
using Charting.Window.Core.Graph;
using OxyPlot;
using Charting.Window.Core.Extensions;

namespace Charting.Window;

public class GraphBuilder
{
    private GraphOptionsBase graphOptions = new GraphOptions();

    public void AddPoint((double x, double y) point)
    {
        if (graphOptions.Points == null)
            graphOptions.Points = new Queue<(double x, double y)>();

        graphOptions.Points.Enqueue(point);
    }

    public GraphBuilder SetPoints(IEnumerable<(double x, double y)> points)
    {
        graphOptions.Points = new Queue<(double x, double y)>(points);
        return this;
    }
    public GraphBuilder SetPoints(IEnumerable<Tuple<double, double>> points)
    {
        graphOptions.Points = new Queue<(double x, double y)>(points.ToIEnumerableTuple());
        return this;
    }
    public GraphBuilder UseInterpolationAlgorithm(InterpolationAlgorithm interpolationAlgorithm)
    {
        switch (interpolationAlgorithm)
        {
            case InterpolationAlgorithm.CanonicalSpline:
                graphOptions.InterpolationAlgorithm = InterpolationAlgorithms.CanonicalSpline;
                break;
            case InterpolationAlgorithm.CatmullRomSpline:
                graphOptions.InterpolationAlgorithm = InterpolationAlgorithms.CatmullRomSpline;
                break;
            case InterpolationAlgorithm.UniformCatmullRomSpline:
                graphOptions.InterpolationAlgorithm = InterpolationAlgorithms.UniformCatmullRomSpline;
                break;
            case InterpolationAlgorithm.ChordalCatmullRomSpline:
                graphOptions.InterpolationAlgorithm = InterpolationAlgorithms.ChordalCatmullRomSpline;
                break;
            default:
                throw new ArgumentException();
        }
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
    public GraphBuilder SetColor(Color color)
    {
        graphOptions.GraphColor = color;
        return this;
    }

    public ISeriesItemCreator Build() => graphOptions;
}