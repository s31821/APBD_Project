using DeviceManager.Exceptions;

namespace DeviceManager.Devices;

public class PersonalComputer(string id, string name, bool on, string? operatingSystem)
    : ADevice(id, name, on)
{
    private string? _operatingSystem = (operatingSystem == "" ? null : operatingSystem);

    public override void TurnOn()
    {
        if (On)
        {
            Console.WriteLine("Device is already on");
            return;
        }
        if (_operatingSystem == null)
        {
            throw new EmptySystemException("Can't turn on a computer without an operating system");
        }
        On = true;
    }

    public void InstallOS(string operatingSystem)
    {
        _operatingSystem = operatingSystem;
    }

    public override string ToString()
    {
        return base.ToString()+ (operatingSystem == null ? "" : ','+operatingSystem);
    }
}