using Charting.Window.Graphics;

namespace Charting.Window.Core.Environment;

class TextColorSetter : IDesignSetter
{
    public Color TextColor { get; set; }

    public TextColorSetter(Color textColor)
    {
        TextColor = textColor;
    }

    public void SetOption(IGraphics graphics)
    {
        graphics.TextColor = TextColor;
    }
}
