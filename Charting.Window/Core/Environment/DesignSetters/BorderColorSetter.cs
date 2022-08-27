using Charting.Window.Graphics;

namespace Charting.Window.Core.Environment;

class BorderColorSetter : IDesignSetter
{
    public Color BorderColor { get; set; }

    public BorderColorSetter(Color borderColor)
    {
        BorderColor = borderColor;
    }

    public void SetOption(IGraphics graphics)
    {
        graphics.BorderColor = BorderColor;
    }
}
