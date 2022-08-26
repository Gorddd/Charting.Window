using Charting.Window.Graphics;
using OxyPlot;

namespace Charting.Window.Core.Environment;

abstract class WindowOptionsBase : IGraphicsCreator
{
    protected IGraphics graphics;

    protected WindowOptionsBase(IGraphics graphics)
    {
        this.graphics = graphics;
        this.graphics.PlotModel = new PlotModel();
    }

    protected List<IDesignSetter> designOptions  = new List<IDesignSetter>();

    public void AddDesignSetter(IDesignSetter designSetter) =>
        designOptions.Add(designSetter);

    public abstract IGraphics CreateGraphics();
}
