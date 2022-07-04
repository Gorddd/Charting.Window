using Charting.Window.Core.Environment;

namespace Charting.Window.Environment;

public class DesignBuilder
{
    private WindowOptionsBase optionsBase = new WindowOptions();

    public void SetTitle(string title) => optionsBase.Title = title;
}
