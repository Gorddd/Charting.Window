using Charting.Window.Graphics;
using OxyPlot;

namespace Charting.Window.Core.Environment;

class WindowCreator : WindowOptionsBase
{
    public WindowCreator(IGraphics graphics) : base(graphics) { }

    public override IGraphics CreateGraphics()
    {
        //установка настроек окна и тд, та же -10 из UPdate

        graphics.VisiblePoints = VisiblePoints;
        graphics.Color = BackColor;

        return graphics;
    }

    public override PlotModel CreatePlotModel() => PlotModel;
}

