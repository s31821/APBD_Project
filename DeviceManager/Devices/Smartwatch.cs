namespace DeviceManager.Devices;

public class Smartwatch : DeviceBuilder, IPowerNotifier
{
    private int power;
    Smartwatch(string id, string name, bool on, int power) : base(name, name, on)
    {
        this.power = power;
    }
    public void Notify(string name, int power)
    {
        Console.WriteLine(name + "'s power is at " + power + "%");
    }
}