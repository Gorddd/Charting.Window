using Charting.Window.Graphics;

namespace Charting.Window.Core.Environment;

class TitleSetter : IDesignSetter
{
    public string Title { get; set; }

    public TitleSetter(string title)
    {
        Title = title;
    }

    public void SetOption(IGraphics graphics)
    {
        graphics.PlotModel.Title = Title;
    }
}
