using Charting.Window.Graphics;
using Charting.Window.Graphics.WindowsForms;
using OxyPlot;

namespace Charting.Window.Core;

class GraphicsAndCoreConnector : IConnector
{
    IGraphics graphics;
    IPlotModelCreator plotModelCreator;
    ISeriesItemCreator seriesItemCreator;

    public bool IsActivated { get; set; }

    //Тут наверное сделать чтобы принимал IEnumerable<ISeriesItemCreator> чтобы все графики создать
    public GraphicsAndCoreConnector(IGraphics graphics, IPlotModelCreator plotModel, ISeriesItemCreator seriesItem)
    {
        this.plotModelCreator = plotModel;
        this.seriesItemCreator = seriesItem;
        this.graphics = graphics;

        BuildForm();
    }

    private void BuildForm()
    {
        var plotModel = plotModelCreator.CreatePlotModel();
        plotModel.Series.Add(seriesItemCreator.CreateSeries());
        graphics.PlotModel = plotModel;
    }

    public async Task StartCharting()
    {
        IsActivated = true;
        await Task.Run(() => graphics.Start());
    }

    public void StopCharting()
    {
        IsActivated = false;
        graphics.Stop();
    }
}
