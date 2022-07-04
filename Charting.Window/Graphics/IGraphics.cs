using OxyPlot;

namespace Charting.Window.Graphics;

public interface IGraphics
{
    PlotModel PlotModel { get; set; }
    void Start();
    void Stop();
}
