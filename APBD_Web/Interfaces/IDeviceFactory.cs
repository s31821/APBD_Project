using APBD_Web.Interfaces;

namespace DeviceManager.Interfaces;

public interface IDeviceFactory
{
    IDevice CreateDevice(string input);
}