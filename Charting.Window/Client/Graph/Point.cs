using OxyPlot;

namespace Charting.Window;

public struct Point
{
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; private set; }
    public double Y { get; private set; }

    public DataPoint ToDataPoint()
    {
        return new DataPoint(X, Y);
    }
}
