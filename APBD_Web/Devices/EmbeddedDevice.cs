using System.Text.RegularExpressions;
using APBD_Web.Interfaces;
using DeviceManager.Exceptions;

namespace DeviceManager.Devices;

public class EmbeddedDevice : IDevice
{
    private readonly string _ipAddress;
    private readonly string _network;

    public EmbeddedDevice(string id, string name, bool on, string ipAddress, string network)
    {
        Id = id;
        Name = name;
        IsOn = on;
        var ipRegex = new Regex(@"^([0-9]{1,3}\.){3}[0-9]{1,3}$");
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
        if (!_network.Contains("MD Ltd.")) throw new ConnectionException("No network found");
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

        Connect();
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
        return Id+","+Name+","+IsOn+','+ _ipAddress + "," + _network;
    }
}