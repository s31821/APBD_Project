namespace DeviceManager.Devices;

public interface IPowerNotifier
{
    void Notify(string name, int power);
}