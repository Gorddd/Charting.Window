using Charting.Window.Graphics;

namespace Charting.Window;

public class GraphCreator
{
    public GraphCreator()
    {
        
    }

    public static async Task Start(Func<double, double> func, string? title = null)
    {
        GraphWindow graphWindow = new GraphWindow(func, title);
        await Task.Run(() => graphWindow.ShowDialog());
    }
}

