namespace Adapter;

public class FIleLoggerAdapter : ILogger
{
    private readonly FileWriter _fileWriter;

    public FIleLoggerAdapter(FileWriter fileWriter)
    {
        _fileWriter = fileWriter;
    }

    public void Log(string message)
    {
        _fileWriter.WriteLine($"[{DateTime.Now:hh:mm:ss}][INFO]: {message}");
    }
    
    public void Error(string message)
    {
        _fileWriter.WriteLine($"[{DateTime.Now:hh:mm:ss}][ERROR]: {message}");
    }

    public void Warn(string message)
    {
        _fileWriter.WriteLine($"[{DateTime.Now:hh:mm:ss}][WARN]: {message}");
    }
}