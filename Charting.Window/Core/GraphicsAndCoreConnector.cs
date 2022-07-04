using Charting.Window.Graphics;

namespace Charting.Window.Core;

class GraphicsAndCoreConnector : IConnector
{
    IGraphics graphics;
    IPlotModelCreator plotModel;
    ISeriesItemCreator seriesItem;

    public bool IsActivated { get; set; }

    public GraphicsAndCoreConnector(IGraphics graphics, IPlotModelCreator plotModel, ISeriesItemCreator seriesItem)
    {
        this.graphics = graphics;
        this.plotModel = plotModel;
        this.seriesItem = seriesItem;
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
