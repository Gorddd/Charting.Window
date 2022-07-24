using Charting.Window.Graphics;
using OxyPlot.Series;
using OxyPlot;
using Charting.Window.Core.Environment;

namespace Charting.Window.Core;

class GraphicsAndCoreConnector : IConnector
{
    private IEnumerable<Series> series; //тонкое место, нужно бы как то отдалиться от Series типа, мб какой-то series controller

    IGraphics graphics;
    IEnumerable<ISeriesItemCreator> seriesItemCreators;

    public bool IsActive { get; set; }

    public GraphicsAndCoreConnector(
        IWindowOptions windowOptions,
        IEnumerable<ISeriesItemCreator> seriesItemCreators)
    {
        this.seriesItemCreators = seriesItemCreators;

        BuildForm(windowOptions);
    }

    private void BuildForm(IWindowOptions windowOptions)
    {
        var plotModel = windowOptions.CreatePlotModel();

        foreach (var seriesItemCreator in seriesItemCreators)
            plotModel.Series.Add(seriesItemCreator.CreateSeries());
        series = plotModel.Series; //здесь получаем это тонкое место

        graphics = windowOptions.CreateGraphics();
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