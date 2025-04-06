using System.Text.RegularExpressions;

namespace Proxy;

public class SmartTextReaderLocker : ISmartTextReader
{
    private readonly Regex _restrictionPattern;
    private readonly SmartTextReader _reader;

    public SmartTextReaderLocker(SmartTextReader reader, string restrictionPattern)
    {
        _reader = reader;
        _restrictionPattern = new Regex(restrictionPattern, RegexOptions.Compiled);
    }

    public char[][] ReadFile(string path)
    {
        if (_restrictionPattern.IsMatch(path))
        {
            return _reader.ReadFile(path);
        }
        
        Console.WriteLine("Access denied");
        return [];
    }
}