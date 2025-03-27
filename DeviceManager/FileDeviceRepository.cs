using DeviceManager.Interfaces;

namespace DeviceManager;

public class FileDeviceRepository : IDeviceRepository
{
    private readonly string _filePath;
    private readonly IDeviceFactory _deviceFactory;

    public FileDeviceRepository(string filePath, IDeviceFactory deviceFactory)
    {
        _filePath = filePath;
        _deviceFactory = deviceFactory;
    }

    public List<IDevice> LoadDevices()
    {
        var devices = new List<IDevice>();

        if (!File.Exists(_filePath))
            return devices;

        foreach (var line in File.ReadAllLines(_filePath))
            try
            {
                devices.Add(_deviceFactory.CreateDevice(line));
            }
            catch
            {
                Console.WriteLine($"Skipping invalid device entry: {line}");
            }

        return devices;
    }

    public void SaveDevices(List<IDevice> devices)
    {
        File.WriteAllLines(_filePath, devices.ConvertAll(d => d.Serialize()));
    }
}