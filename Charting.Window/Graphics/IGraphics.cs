using OxyPlot;

namespace Charting.Window.Graphics;

public interface IGraphics
{
    PlotModel PlotModel { get; set; }

    string WindowName { get; set; }

    int VisiblePoints { get; set; }

    Color BackColor { get; set; }

    Color BorderColor { set; }

    Color TextColor { set; }

    Color TitleColor { set; }

    void Start();

    void Stop();

    void UpdateArea();
}
