namespace Proxy;

public class SmartTextReader : ISmartTextReader
{
    public char[][] ReadFile(string path)
    {
        return File
            .ReadAllLines(path)
            .Select(line => line.ToCharArray())
            .ToArray();
    }
}