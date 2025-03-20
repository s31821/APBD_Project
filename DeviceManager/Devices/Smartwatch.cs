using DeviceManager.Exceptions;

namespace DeviceManager.Devices;

public class Smartwatch : ADevice, IPowerNotifier
{
    private int _power;
    public Smartwatch(string id, string name, bool on, int power) : base(id, name, on)
    {
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

    public override void TurnOn()
    {
        if (On)
        {
            Console.WriteLine("Device is already on");
            return;
        }
        if (_power < 11)
        {
            throw new EmptyBatteryException("Not enough power to turn on");
        }
        On = true;
        _power -= 10;
    }

    public override string ToString()
    {
        return (base.ToString()+','+_power+'%');
    }
}