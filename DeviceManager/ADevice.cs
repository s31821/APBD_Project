namespace DeviceManager;

public abstract class ADevice(string id, string name, bool on)
{
    protected bool On = on;

    public virtual string GetDeviceId()
    {
        return id;
    }

    public virtual string GetDeviceName()
    {
        return name;
    }

    public virtual bool IsDeviceOn()
    {
        return On;
    }

    public virtual void TurnOn()
    {
        if (On)
        {
            Console.WriteLine("Device is already on");
            return;
        }
        On = true;
    }

    public virtual void TurnOff()
    {
        if (!On)
        {
            Console.WriteLine("Device is already off");
            return;
        }
        On = false;
    }
}