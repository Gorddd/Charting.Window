using Charting.Window.Core;

namespace Charting.Window;

public class GraphCreator
{
    private Func<double, double> func;

    public GraphCreator(Func<double, double> func)
    {
        this.func = func;
    }

    public async Task Start(string? title = null)
    {
        await Task.Run(() => 
        {
            Application.EnableVisualStyles();
            Application.Run(new GraphWindow(func, title));
        });
    }
}

