using Charting.Window.Graphics;
using Charting.Window.Graphics.WindowsForms;
using OxyPlot;

namespace Charting.Window.Core;

class GraphicsAndCoreConnector : IConnector
{
    private IEnumerable<OxyPlot.Series.Series> series;

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
        series = plotModel.Series;

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
        var seriesEnumerator = series.GetEnumerator();
        foreach (var seriesItemCreator in seriesItemCreators)
        {
            seriesEnumerator.MoveNext();

            seriesItemCreator.UpdateSeries(seriesEnumerator.Current);
        }
        seriesEnumerator.Reset();
    }
}