using OxyPlot;

namespace Charting.Window.Graphics;

public interface IGraphics
{
    PlotModel PlotModel { get; set; }
    int VisiblePoints { get; set; }
    Color Color { get; set; }
    void Start();
    void Stop();
    void UpdateArea();
}
