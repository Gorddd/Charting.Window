using Charting.Window.Graphics;

namespace Charting.Window.Core.Environment;

class BackColorSetter : IDesignSetter
{
    public Color BackColor { get; set; }

    public BackColorSetter(Color backColor)
    {
        BackColor = backColor;
    }

    public void SetOption(IGraphics graphics)
    {
        graphics.BackColor = BackColor;
    }
}
