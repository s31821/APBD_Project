using APBD_Web.Interfaces;

namespace DeviceManager.Interfaces;

public interface IDeviceRepository
{
    void SaveDevices(List<IDevice> devices);
    List<IDevice> LoadDevices();
}