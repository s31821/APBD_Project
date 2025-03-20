using DeviceManager.Devices;
using DeviceManager.Exceptions;

namespace DeviceManager;

public class DevMan
{
    List<ADevice> _devices = [];
    private String filepath;
    public DevMan(string filepath)
    {
        this.filepath = filepath;
        if (!File.Exists(filepath))
        {
            throw new FileNotFoundException();
        }
        FileStream fileStream = File.Open(filepath, FileMode.Open, FileAccess.ReadWrite);
        StreamReader streamReader = new StreamReader(fileStream);
        while (streamReader.Peek() != -1)
        {
            try
            {
                AddDevice(streamReader.ReadLine());
            }
            catch (FullDeviceManagerException)
            {
                Console.WriteLine("Couldn't read all devices from file, capacity reached");
                break;
            }
        }
        streamReader.Close();
        fileStream.Close();
        fileStream.Dispose();
    }

    public void AddDevice(String input)
    {
        if (_devices.Count == 15)
        {
            throw new FullDeviceManagerException("No space in device manager. Remove a device to add more.");
        }
        string[] line = input.Split(",");
        try
        {
            if (line[0].StartsWith("SW"))
            {
                _devices.Add(new Smartwatch(line[0], line[1], bool.Parse(line[2]), int.Parse(line[3].Trim('%'))));
            }
            else if (line[0].StartsWith('P'))
            {
                if (line.Length == 3)
                {
                    _devices.Add(new PersonalComputer(line[0], line[1], bool.Parse(line[2]), null));
                }
                else
                {
                    _devices.Add(new PersonalComputer(line[0], line[1], bool.Parse(line[2]), line[3]));
                }

            }
            else if (line[0].StartsWith("ED"))
            {
                _devices.Add(new EmbeddedDevice(line[0], line[1], bool.Parse(line[2]), line[3], line[4]));
            }
        }
        catch
        {
            Console.WriteLine("Invalid device in file, skipping...");
        }
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

    public void RemoveDevice()
    {
        ListDevices();
        Console.WriteLine("Select the device you want to remove");
        int select = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Removed " + _devices[select].GetDeviceName());
        _devices.RemoveAt(select);
    }

    public void ListDevices()
    {
        for (int i = 0; i < _devices.Count; i++)
        {
            Console.WriteLine(i + ". " + _devices[i].ToString());
        }
    }
    public void TurnOnDevice()
    {
        ListDevices();
        Console.WriteLine("Select the device you want to turn on");
        int select = Int32.Parse(Console.ReadLine());
        try
        {
            _devices[select].TurnOn();
            Console.WriteLine("Turned on " + _devices[select].GetDeviceName());
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
        _devices[select].TurnOff();
    }
    public void SaveDevicesToFile()
    {
        String[] lines = new string[_devices.Count];
        for (int i = 0; i < _devices.Count; i++)
        {
            lines[i] = _devices[i].ToString();
        }
        File.WriteAllLines(filepath, lines);
        Console.WriteLine("Saved devices to " + filepath);
    }
}