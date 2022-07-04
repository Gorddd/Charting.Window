using OxyPlot;

namespace Charting.Window.Graphics;

interface IGraphics
{
    PlotModel PlotModel { get; set; }
    void Start();
    void Stop();
}
