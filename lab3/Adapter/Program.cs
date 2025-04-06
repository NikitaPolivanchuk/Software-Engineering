namespace Adapter;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        List<ILogger> loggers = [
            new Logger(),
            new FIleLoggerAdapter(new FileWriter("logs.log"))
        ];
        
        foreach (var logger in loggers)
        {
            logger.Error("Error");
            logger.Log("Info");
            logger.Warn("Warning");
        }
    }
}