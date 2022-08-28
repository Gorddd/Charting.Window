using Charting.Window.Core.Environment;
using Charting.Window.Graphics;
using Charting.Window.Graphics.WindowsForms;

namespace Charting.Window;

public class DesignBuilder
{
    private WindowOptionsBase options = new WindowCreator(new WinformsWindow());

    public DesignBuilder SetTitle(string title) 
    {
        options.AddDesignSetter(new TitleSetter(title));
        return this;
    }

    public DesignBuilder SetVisiblePoints(int amount)
    {
        options.AddDesignSetter(new VisiblePointsSetter(amount));
        return this;
    }

    public DesignBuilder SetBackColor(Color color)
    {
        options.AddDesignSetter(new BackColorSetter(color));
        return this;
    }

    public DesignBuilder SetBorderColor(Color color)
    {
        options.AddDesignSetter(new BorderColorSetter(color));
        return this;
    }

    public DesignBuilder SetTextColor(Color color)
    {
        options.AddDesignSetter(new TextColorSetter(color));
        return this;
    }

    public DesignBuilder SetTitleColor(Color color)
    {
        options.AddDesignSetter(new TitleColorSetter(color));
        return this;
    }

    public DesignBuilder SetWindowName(string name)
    {
        options.AddDesignSetter(new WindowNameSetter(name));
        return this;
    }

    public IGraphicsCreator Build() => options;
}
