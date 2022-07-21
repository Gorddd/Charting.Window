namespace Charting.Window.Core;

public interface IConnector
{
    Task StartCharting();
    void StopCharting();
    void Update();
    bool IsActive { get; set; }
}
