using DeviceManager.Exceptions;

namespace DeviceManager.Devices;

public class PersonalComputer : IDevice
{
    private string? _operatingSystem;

    public PersonalComputer(string id, string name, bool on, string? operatingSystem)
    {
        Id = id;
        Name = name;
        IsOn = on;
        _operatingSystem = (operatingSystem == "" ? null : operatingSystem);
    }

    public string Id { get; }
    public string Name { get; }
    public bool IsOn { get; set; }

    public bool TurnOn()
    {
        if (IsOn)
        {
            Console.WriteLine("Device is already on");
            return false;
        }
        if (_operatingSystem == null)
        {
            throw new EmptySystemException("Can't turn on a computer without an operating system");
        }
        IsOn = true;
        return true;
    }

    public bool TurnOff()
    {
        if (!IsOn)
        {
            Console.WriteLine("Device is already off");
            return false;
        }
        IsOn = false;
        return true;
    }

    public string Serialize()
    {
        return Id+","+Name+","+IsOn+','+(_operatingSystem == null ? "" : ','+_operatingSystem);
    }

    public void InstallOS(string operatingSystem)
    {
        _operatingSystem = operatingSystem;
    }
}