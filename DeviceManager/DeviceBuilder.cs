namespace DeviceManager;

public abstract class DeviceBuilder
{
    private string id;
    private string name;
    private bool on;

    public DeviceBuilder(string id, string name, bool on)
    {
        this.id = id;
        this.name = name;
        this.on = on;
    }
    
    string GetDeviceID()
    {
        return id;
    }

    string GetDeviceName()
    {
        return name;
    }

    bool IsDeviceOn()
    {
        return on;
    }

    void TurnOn()
    {
        if (on)
        {
            Console.WriteLine("Device is already on");
            return;
        }
        on = true;
    }

    void TurnOff()
    {
        if (!on)
        {
            Console.WriteLine("Device is already off");
            return;
        }
        on = false;
    }
}