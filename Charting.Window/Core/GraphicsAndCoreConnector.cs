using Charting.Window.Graphics;
using OxyPlot.Series;
using OxyPlot;

namespace Charting.Window.Core;

class GraphicsAndCoreConnector : IConnector
{
    private IEnumerable<Series> series; //тонкое место, нужно бы как то отдалиться от Series типа, мб какой-то series controller

    IGraphics graphics;
    IPlotModelCreator plotModelCreator;
    IEnumerable<ISeriesItemCreator> seriesItemCreators;

    public bool IsActive { get; set; }

    public GraphicsAndCoreConnector(
        IGraphics graphics,
        IPlotModelCreator plotModelCreator,
        IEnumerable<ISeriesItemCreator> seriesItemCreators)
    {
        this.plotModelCreator = plotModelCreator;
        this.seriesItemCreators = seriesItemCreators;
        this.graphics = graphics;

        BuildForm();
    }

    private void BuildForm()
    {
        var plotModel = plotModelCreator.CreatePlotModel();

        foreach (var seriesItemCreator in seriesItemCreators)
            plotModel.Series.Add(seriesItemCreator.CreateSeries());
        series = plotModel.Series; //здесь получаем это тонкое место

        graphics.PlotModel = plotModel;
    }

    public async Task StartCharting()
    {
        IsActive = true;
        await Task.Run(() => graphics.Start());
    }

    public void StopCharting()
    {
        IsActive = false;
        graphics.Stop();
    }

    public void Update()
    {
        var seriesEnumerator = series.GetEnumerator();//используем тонкое место
        foreach (var seriesItemCreator in seriesItemCreators)
        {
            seriesEnumerator.MoveNext();

            seriesItemCreator.UpdateSeries(seriesEnumerator.Current);
        }
        seriesEnumerator.Reset();

        graphics.UpdateArea();
    }
}