using DeviceManager.Devices;
using DeviceManager.Interfaces;

namespace DeviceManager;

public class DeviceFactory : IDeviceFactory
{
    public IDevice CreateDevice(string input)
    {
        string[] data = input.Split(",");
        try
        {
            return data[0] switch
            {
                var id when id.StartsWith("SW") => new Smartwatch(data[0], data[1], bool.Parse(data[2]),
                    int.Parse(data[3].Trim('%'))),
                var id when id.StartsWith("P") => new PersonalComputer(data[0], data[1], bool.Parse(data[2]),
                    data.Length > 3 ? data[3] : null),
                var id when id.StartsWith("ED") => new EmbeddedDevice(data[0], data[1], bool.Parse(data[2]), data[3],
                    data[4]),
                _ => throw new ArgumentException("Unknown device type")
            };
        }
        catch
        {
            throw new ArgumentException("Invalid device format");
        }
    }
}