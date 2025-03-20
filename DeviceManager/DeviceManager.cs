using DeviceManager.Devices;

namespace DeviceManager;

public class DeviceManager
{
    FileStream fileStream;
    StreamWriter streamWriter;
    StreamReader streamReader;
    List<ADevice> devices;
    public DeviceManager(string filepath)
    {
        if (!File.Exists(filepath))
        {
            throw new FileNotFoundException("File not found");
        }
        fileStream = File.Open(filepath, FileMode.Open, FileAccess.ReadWrite);
        streamReader = new StreamReader(fileStream);
        streamWriter = new StreamWriter(fileStream);
        streamWriter.AutoFlush = true;
        while (streamReader.Peek() != -1)
        {
            string[] line = streamReader.ReadLine().Split(",");
            if (line[0].StartsWith("SW"))
            {
                try
                {
                    devices.Add(new Smartwatch(line[0], line[1], bool.Parse(line[2]), int.Parse(line[3].Trim('%'))));
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid device, skipping.");
                }
            }
            else if (line[0].StartsWith("P"))
            {
                
            }
            else if (line[0].StartsWith("ED"))
            {
                
            }
            else
            {
                Console.WriteLine("Invalid device, skipping.");
            }
            
        }
        
    }
}