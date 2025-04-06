namespace Proxy;

public class SmartTextChecker : ISmartTextReader
{
    public char[][] ReadFile(string path)
    {
        var stream = File.OpenRead(path);
        Console.WriteLine($"File '{path}' opened successfully");
        
        var lines = new List<char[]>();
        var charCount = 0;
        using (var reader = new StreamReader(stream))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line.ToCharArray());
                charCount += line.Length;
            }
        }
        Console.WriteLine("All lines read successfully");
        
        stream.Close();
        Console.WriteLine($"File '{path}' closed successfully");
        
        Console.WriteLine($"Total lines: {lines.Count}, Total characters: {charCount}");
        
        return lines.ToArray();
    }
}