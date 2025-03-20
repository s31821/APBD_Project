using System.Text.RegularExpressions;
using DeviceManager.Exceptions;

namespace DeviceManager.Devices;

public class EmbeddedDevice : ADevice
{
    private string _ipAddress;
    private string _network;
    public EmbeddedDevice(string id, string name, bool on, string ipAddress, string network) : base(id, name, on)
    {
        Regex ipRegex = new Regex(@"^([0-9]{1,3}\.){3}[0-9]{1,3}$");
        if (ipRegex.IsMatch(ipAddress))
        {
            _ipAddress = ipAddress;
            _network = network;
        }
        else
        {
            throw new ArgumentException("Invalid IP address");
        }
    }

    public void Connect()
    {
        if (!_network.Contains("MD Ltd."))
        {
            throw new ConnectionException();
        }
    }

    public override void TurnOn()
    {
        if (On)
        {
            Console.WriteLine("Device is already on");
            return;
        }
        Connect();
        On = true;
    }
}