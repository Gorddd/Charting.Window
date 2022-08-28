using Charting.Window.Core;

namespace Charting.Window;

/// <summary>
/// Start charting
/// </summary>
public class GraphCreator
{
    private IConnector connector;

    public bool IsActive => connector.IsActive;

    /// <summary>
    /// Constructor of GraphCreator
    /// </summary>
    /// <param name="graphBuilder">Graph options object</param>
    /// <param name="designBuilder">Window options object</param>
    public GraphCreator(GraphBuilder graphBuilder, DesignBuilder? designBuilder = null)
    {
        var seriesItemCreators = BuildersToSeriesCreators(new[] { graphBuilder });
        connector = new GraphicsAndCoreConnector(
            designBuilder?.Build() ?? new DesignBuilder().Build(),
            seriesItemCreators);
    }

    /// <summary>
    /// Constructor of GraphCreator
    /// </summary>
    /// <param name="graphBuilders">Collection of GraphBuilder</param>
    /// <param name="designBuilder">Window options object</param>
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

    /// <summary>
    /// Display the window
    /// </summary>
    /// <returns></returns>
    public async Task Start() => await connector.StartCharting();

    /// <summary>
    /// Hide the window
    /// </summary>
    public void Stop() => connector.StopCharting();

    /// <summary>
    /// Update series
    /// </summary>
    public void Update() => connector.Update();


    /// <summary>
    /// Fast charting
    /// </summary>
    /// <param name="func">Function to build</param>
    /// <param name="title">Title</param>
    /// <returns></returns>
    public static async Task Start(Func<double, double> func, string? title = null)
    {
        var graphBuilder = new GraphBuilder().SetFunction(func).SetName(title);
        var designBuilder = new DesignBuilder().SetTitle(title);

        var session = new GraphicsAndCoreConnector(
            designBuilder.Build(),
            BuildersToSeriesCreators(new[] { graphBuilder }));

        await session.StartCharting();
    }

    /// <summary>
    /// Fast charting
    /// </summary>
    /// <param name="points">Collection of (double x, double y)</param>
    /// <param name="interpolationAlgorithm">Type of estimating unknown values</param>
    /// <param name="title">title</param>
    /// <returns></returns>
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