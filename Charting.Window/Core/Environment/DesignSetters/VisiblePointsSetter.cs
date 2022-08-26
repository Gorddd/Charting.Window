using Charting.Window.Graphics;

namespace Charting.Window.Core.Environment;

class VisiblePointsSetter : IDesignSetter
{
    public int VisiblePoints { get; set; }

    public VisiblePointsSetter(int visiblePoints)
    {
        VisiblePoints = visiblePoints;
    }

    public void SetOption(IGraphics graphics)
    {
        graphics.VisiblePoints = VisiblePoints;
    }
}
