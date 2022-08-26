using Charting.Window.Graphics;

namespace Charting.Window.Core.Environment;

class WindowCreator : WindowOptionsBase
{
    public WindowCreator(IGraphics graphics) : base(graphics) { }

    public override IGraphics CreateGraphics()
    {
        foreach (var option in designOptions)
            option.SetOption(graphics);

        return graphics;
    }
}

