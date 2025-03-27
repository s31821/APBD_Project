namespace DeviceManager;

public interface IDevice
{
    string Id { get; }
    string Name { get; }
    bool IsOn { get; }
    bool TurnOn();
    bool TurnOff();
    string Serialize();
}