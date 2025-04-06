namespace Adapter;

public class FileWriter
{
    private readonly string _filePath;

    public FileWriter(string filePath)
    {
        _filePath = filePath;
    }
    
    public void Write(string content)
    {
        File.AppendAllText(_filePath, content);
    }

    public void WriteLine(string content)
    {
        File.AppendAllText(_filePath, $"{content}{Environment.NewLine}");
    }
}