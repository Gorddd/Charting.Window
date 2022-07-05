using Charting.Window.Graphics;
using Charting.Window.Graphics.WindowsForms;
using OxyPlot;

namespace Charting.Window.Core;

class GraphicsAndCoreConnector : IConnector
{
    IGraphics graphics;
    IPlotModelCreator plotModelCreator;
    IEnumerable<ISeriesItemCreator> seriesItemCreators;

    public bool IsActive { get; set; }

    //Тут наверное сделать чтобы принимал IEnumerable<ISeriesItemCreator> чтобы все графики создать
    public GraphicsAndCoreConnector(IGraphics graphics, IPlotModelCreator plotModelCreator, IEnumerable<ISeriesItemCreator> seriesItemCreators)
    {
        this.plotModelCreator = plotModelCreator;
        this.seriesItemCreators = seriesItemCreators;
        this.graphics = graphics;

        BuildForm();
    }

    private void BuildForm()
    {
        var plotModel = plotModelCreator.CreatePlotModel();

        foreach(var seriesItemCreator in seriesItemCreators)
            plotModel.Series.Add(seriesItemCreator.CreateSeries());

        graphics.PlotModel = plotModel;
    }

    public async Task StartCharting()
    {
        IsActive = true;
        await Task.Run(() => graphics.Start());
        graphics.Start();
    }

    public void StopCharting()
    {
        IsActive = false;
        graphics.Stop();
    }
}
