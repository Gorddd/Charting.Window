namespace Charting.Window.Core;

public interface IConnector
{
    Task StartCharting();
    void StopCharting();
    bool IsActive { get; set; }
}
