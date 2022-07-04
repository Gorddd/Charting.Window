using Charting.Window.Core;
using Charting.Window.Core.Environment;

namespace Charting.Window.Environment;

public class DesignBuilder
{
    private WindowOptionsBase options = new WindowOptions();

    public DesignBuilder SetTitle(string title) 
    {
        options.Title = title;
        return this;
    }

    public IPlotModelCreator Build() => options;
}
