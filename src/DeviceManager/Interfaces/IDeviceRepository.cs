namespace DeviceManager.Interfaces;

public interface IDeviceRepository
{
    void SaveDevices(List<IDevice> devices);
    List<IDevice> LoadDevices();
}