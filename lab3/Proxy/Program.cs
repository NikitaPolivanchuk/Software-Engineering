namespace Proxy;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        const string path = "data.txt";

        var service = new SmartTextReader();

        List<ISmartTextReader> readers =
        [
            service,
            new SmartTextChecker(),
            new SmartTextReaderLocker(service, ".*\\.log$")
        ];

        foreach (var reader in readers)
        {
            Console.WriteLine($"Reader: {reader.GetType().Name}");
            reader.ReadFile(path);
            Console.WriteLine();
        }
    }
}