using Charting.Window.Graphics;

namespace Charting.Window.Core.Environment;

class TitleColorSetter : IDesignSetter
{
    public Color TitleColor { get; set; }

    public TitleColorSetter(Color titleColor)
    {
        TitleColor = titleColor;
    }

    public void SetOption(IGraphics graphics)
    {
        graphics.TitleColor = TitleColor;
    }
}
