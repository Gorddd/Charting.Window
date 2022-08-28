using Charting.Window.Graphics;

namespace Charting.Window.Core.Environment;

class WindowNameSetter : IDesignSetter
{
    public string Name { get; set; }

    public WindowNameSetter(string name)
    {
        Name = name;
    }

    public void SetOption(IGraphics graphics)
    {
        graphics.WindowName = Name;
    }
}
