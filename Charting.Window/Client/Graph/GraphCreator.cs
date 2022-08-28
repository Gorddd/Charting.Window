using Charting.Window.Core;

namespace Charting.Window;

public class GraphCreator
{
    private IConnector connector;

    public bool IsActive => connector.IsActive;

    public GraphCreator(GraphBuilder graphBuilder, DesignBuilder? designBuilder = null)
    {
        var seriesItemCreators = BuildersToSeriesCreators(new[] { graphBuilder });
        connector = new GraphicsAndCoreConnector(
            designBuilder?.Build() ?? new DesignBuilder().Build(),
            seriesItemCreators);
    }
    public GraphCreator(IEnumerable<GraphBuilder> graphBuilders, DesignBuilder? designBuilder = null)
    {
        var seriesItemCreators = BuildersToSeriesCreators(graphBuilders);
        connector = new GraphicsAndCoreConnector(
            designBuilder?.Build() ?? new DesignBuilder().Build(),
            seriesItemCreators);
    }

    private static IEnumerable<ISeriesItemCreator> BuildersToSeriesCreators(IEnumerable<GraphBuilder> graphBuilders)
    {
        var seriesItemCreators = new List<ISeriesItemCreator>();

        foreach (var graphBuilder in graphBuilders)
            seriesItemCreators.Add(graphBuilder.Build());

        return seriesItemCreators;
    }

    public async Task Start() => await connector.StartCharting();

    public void Stop() => connector.StopCharting();

    public void Update() => connector.Update();



    public static async Task Start(Func<double, double> func, string? title = null)
    {
        var graphBuilder = new GraphBuilder().SetFunction(func).SetName(title);
        var designBuilder = new DesignBuilder().SetTitle(title);

        var session = new GraphicsAndCoreConnector(
            designBuilder.Build(),
            BuildersToSeriesCreators(new[] { graphBuilder }));

        await session.StartCharting();
    }

    public static async Task Start(IEnumerable<(double, double)> points,
        InterpolationAlgorithm? interpolationAlgorithm = null,
        string? title = null)
    {
        var graphBuilder = new GraphBuilder().SetPoints(points).SetName(title);
        if (interpolationAlgorithm != null)
            graphBuilder.UseInterpolationAlgorithm((InterpolationAlgorithm)interpolationAlgorithm);
        var designBuilder = new DesignBuilder().SetTitle(title);

        var session = new GraphicsAndCoreConnector(
            designBuilder.Build(),
            BuildersToSeriesCreators(new[] { graphBuilder })
            );

        await session.StartCharting();
    }
}