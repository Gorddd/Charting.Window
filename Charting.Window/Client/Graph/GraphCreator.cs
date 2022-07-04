using Charting.Window.Core;
using Charting.Window.Environment;
using Charting.Window.Graphics.WindowsForms;

namespace Charting.Window;

public class GraphCreator : GraphMaker
{
    private IConnector connector;
    public bool IsActivated => connector.IsActivated;

    public GraphCreator(GraphBuilder graphBuilder, DesignBuilder designBuilder)
    {
        connector = new GraphicsAndCoreConnector(new WinformsWindow(), designBuilder.Build(), graphBuilder.Build());
    }
    public GraphCreator(GraphBuilder graphBuilder)
    {
        connector = new GraphicsAndCoreConnector(new WinformsWindow(), new DesignBuilder().Build(), graphBuilder.Build());
    }

    public async Task Start() => await connector.StartCharting();
    public void Stop() => connector.StopCharting();


    public static async Task Start(Func<double, double> func, string? title = null)
    {
        var graphBuilder = new GraphBuilder().SetFunction(func).SetName(title);
        var designBuilder = new DesignBuilder().SetTitle(title);
        var session = new GraphicsAndCoreConnector(new WinformsWindow(), designBuilder.Build(), graphBuilder.Build());

        await session.StartCharting();
    }
}

