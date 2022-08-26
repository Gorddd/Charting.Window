using Charting.Window.Graphics;
using OxyPlot;

namespace Charting.Window.Core.Environment;

class WindowCreator : WindowOptionsBase
{
    public WindowCreator(IGraphics graphics) : base(graphics) { }

    public override IGraphics CreateGraphics()
    {
        foreach (var option in designOptions)
            option.SetOption(graphics);

        return graphics;
    }

    public override PlotModel CreatePlotModel() => graphics.PlotModel;
}

