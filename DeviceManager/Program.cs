using System;
using DeviceManager;

class Program
{
    public static void Main(string[] args)
    {
        DevMan deviceManager=null;
        try
        {
            deviceManager = new DevMan(new FileDeviceRepository("input.txt",new DeviceFactory()));
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Terminating...");
            Environment.Exit(1);
        }
        Console.WriteLine("Welcome to the device manager!\nWhat would you like to do?");
        DisplayHelp();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "help")
            {
                DisplayHelp();
            }
            else if (input == "exit")
            {
                Environment.Exit(0);
            }
            else if (input == "list")
            {
                deviceManager.ListDevices();
            }
            else if (input == "add")
            {
                deviceManager.AddDevice();
            }
            else if (input == "remove")
            {
                deviceManager.RemoveDevice();
            }
            else if (input == "turnon")
            {
                deviceManager.TurnOnDevice();
            }
            else if (input == "turnoff")
            {
                deviceManager.TurnOffDevice();
            }
            else if (input == "save")
            {
                deviceManager.SaveDevices();
            }
            else
            {
                Console.WriteLine("Please enter a valid command. Type 'help' for a list of commands.");
            }
        }
    }

    public static void DisplayHelp()
    {
        Console.WriteLine("help - Displays this message");
        Console.WriteLine("list - List all devices");
        Console.WriteLine("add - Add a new device");
        Console.WriteLine("remove - Remove a device");
        Console.WriteLine("turnon - Turn on a device");
        Console.WriteLine("turnoff - Turn off a device");
        Console.WriteLine("save - Saves all devices to file");
        Console.WriteLine("exit - Exits the program. Unsaved changes will be lost.");
    }
}