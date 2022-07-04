using OxyPlot;

namespace Charting.Window.Core.Environment;

class WindowOptions : WindowOptionsBase
{
    public override PlotModel CreatePlotModel()
    {
        PlotModel model = new PlotModel() { Title = Title };
        return model;
    }
}

