using Charting.Window.Graphics;
using OxyPlot;

namespace Charting.Window.Core.Environment;

abstract class WindowOptionsBase : IWindowOptions
{
    protected IGraphics graphics;

    protected WindowOptionsBase(IGraphics graphics)
    {
        this.graphics = graphics;
    }

    public PlotModel PlotModel { get; set; } = new PlotModel();

    public string? Title
    {
        get => PlotModel.Title;
        set => PlotModel.Title = value;
    }


    public abstract PlotModel CreatePlotModel();
    public abstract IGraphics CreateGraphics();
}
