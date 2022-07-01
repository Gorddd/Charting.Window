using Charting.Window.Core;

namespace Charting.Window;

public class GraphCreator
{
    public GraphCreator()
    {
    }

    public async Task CreateGraph()
    {
        await Task.Run(() => 
        {
            Application.EnableVisualStyles();
            Application.Run(new GraphWindow());
        });
    }
}

