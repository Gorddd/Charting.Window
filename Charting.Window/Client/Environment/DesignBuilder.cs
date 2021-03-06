using Charting.Window.Core;
using Charting.Window.Core.Environment;
using Charting.Window.Graphics.WindowsForms;

namespace Charting.Window.Environment;

public class DesignBuilder
{
    private WindowOptionsBase options = new WindowCreator(new WinformsWindow());

    public DesignBuilder SetTitle(string title) 
    {
        options.Title = title;
        return this;
    }
    public DesignBuilder SetVisiblePoints(int amount)
    {
        options.VisiblePoints = amount;
        return this;
    }
    public DesignBuilder SetBackColor(Color color)
    {
        options.BackColor = color;
        return this;
    }

    public IWindowOptions Build() => options;
}
