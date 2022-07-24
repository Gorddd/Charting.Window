using Charting.Window.Graphics;
using OxyPlot;

namespace Charting.Window.Core.Environment;

class WindowCreator : WindowOptionsBase
{
    public WindowCreator(IGraphics graphics) : base(graphics) { }

    public override IGraphics CreateGraphics()
    {
        //установка настроек окна и тд, та же -10 из UPdate
        return graphics;
    }

    public override PlotModel CreatePlotModel() => PlotModel;
}

