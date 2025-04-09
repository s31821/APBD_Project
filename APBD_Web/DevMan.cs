using APBD_Web.Interfaces;
using DeviceManager.Devices;
using DeviceManager.Exceptions;
using DeviceManager.Interfaces;

namespace DeviceManager;

public class DevMan
{
    private readonly List<IDevice> _devices;
    private readonly IDeviceRepository _repository;

    public DevMan(IDeviceRepository repository)
    {
        _repository = repository;
        _devices = _repository.LoadDevices();
    }

    public void AddDevice(IDevice device)
    {
        if (_devices.Count >= 15)
            throw new FullDeviceManagerException("No space in device manager.");

        _devices.Add(device);
    }
    public void AddDevice()
    {
        if (_devices.Count == 15)
        {
            throw new FullDeviceManagerException("No space in device manager. Remove a device to add more.");
        }
        Console.WriteLine("Input the type of device. SW - Smartwatch, P - Personal Computer, ED - Embedded Device");
        string id = Console.ReadLine();
        while (true)
        {
            if (id == "SW" || id == "P" || id == "ED") break;
            Console.WriteLine("Unrecognized device type. Please try again.");
            id = Console.ReadLine();
        }
        Console.WriteLine("Input the name of the device");
        string name = Console.ReadLine();
        if (id == "SW")
        {
            _devices.Add(new Smartwatch(id, name, false, 100));
            Console.WriteLine("Added Smartwatch "+name+" to devices");
        }
        else if (id == "P")
        {
            Console.WriteLine("Input the operating system. Press enter for no system");
            string? system = Console.ReadLine();
            _devices.Add(new PersonalComputer(id,name,false,system));
            Console.WriteLine("Added Personal Computer "+name+" to devices");
        }
        else if (id == "ED")
        {
            Console.WriteLine("Input the IP address of the device");
            string ip = Console.ReadLine();
            Console.WriteLine("Input the name of the network");
            string network = Console.ReadLine();
            try
            {
                _devices.Add(new EmbeddedDevice(id, name, false, ip, network));
                Console.WriteLine("Added "+name+" to devices");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid ip address");
            }
        }
    }

    public void RemoveDevice(int index)
    {
        if (index < 0 || index >= _devices.Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        _devices.RemoveAt(index);
    }
    
    public void RemoveDevice()
    {
        ListDevices();
        Console.WriteLine("Select the device you want to remove");
        int select = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Removed " + _devices[select].Name);
        _devices.RemoveAt(select);
    }

    public string ListDevices()
    {
        string output = "";
        for (var i = 0; i < _devices.Count; i++) output+=($"{i}. {_devices[i].Serialize()}\n");
        return output;
    }

    public string ListDevices(int id)
    {
        if (id < 0 || id >= _devices.Count)
        {
            return "Id is out of range.";
        }
        return _devices[id].Serialize();
    }

    public IResult EditDevice(IDevice device)
    {
        if (int.Parse(device.Id) < 0 || int.Parse(device.Id) >= _devices.Count)
        {
            return Results.NoContent();
        }
        _devices[int.Parse(device.Id)] = device;
        return Results.Ok();
    }

    public void TurnOnDevice()
    {
        ListDevices();
        Console.WriteLine("Select the device you want to turn on");
        int select = int.Parse(Console.ReadLine());
        try
        {
            if (_devices[select].TurnOn())
            {
                Console.WriteLine("Turned on " + _devices[select].Name);
            }
            
        }
        catch (EmptySystemException)
        {
            Console.WriteLine("Can't turn on devices without an operating system");
        }
    }

    public void TurnOffDevice()
    {
        ListDevices();
        Console.WriteLine("Select the device you want to turn off");
        int select = Int32.Parse(Console.ReadLine());
        if (_devices[select].TurnOff())
        {
            Console.WriteLine("Turned off " + _devices[select].Name);
        }
        
    }

    public void SaveDevices()
    {
        _repository.SaveDevices(_devices);
    }
}