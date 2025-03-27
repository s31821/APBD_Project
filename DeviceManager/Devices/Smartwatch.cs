using DeviceManager.Exceptions;

namespace DeviceManager.Devices;

public class Smartwatch : IDevice, IPowerNotifier
{
    private int _power;
    public Smartwatch(string id, string name, bool on, int power)
    {
        Id = id;
        Name = name;
        IsOn = on;
        _power = power;
        switch (_power)
        {
            case < 0:
                _power = 0;
                break;
            case > 100:
                _power = 100;
                break;
        }
        if (_power < 20)
        {
            Notify(name);
        }
    }
    public void Notify(string name)
    {
        Console.WriteLine(name + "'s power is at " + _power + "%");
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
        if (_power < 11)
        {
            throw new EmptyBatteryException("Not enough power to turn on");
        }
        IsOn = true;
        _power -= 10;
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
        return Id+","+Name+","+IsOn+','+_power+'%';
    }

}