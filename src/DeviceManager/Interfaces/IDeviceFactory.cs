namespace DeviceManager.Interfaces;

public interface IDeviceFactory
{
    IDevice CreateDevice(string input);
}