using System.Numerics;

namespace DeviceManager;

public class DeviceManager
{
    FileStream fileStream;
    StreamWriter streamWriter;
    StreamReader streamReader;
    Vector<DeviceBuilder> devices = new Vector<DeviceBuilder>();
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
        while (fileStream.Position < fileStream.Length)
        {
            string[] line = streamReader.ReadLine().Split(",");
            if (line[0].StartsWith("SW"))
            {
                
            }
            
        }
        
    }
}