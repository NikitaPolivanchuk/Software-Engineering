namespace ChainOfResponsibility;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        var handlers = new List<ISupportHandler>()
        {
            new BasicSupportHandler(),
            new TechnicalSupportHandler(),
            new BillingSupportHandler(),
            new SupervisorSupportHandler()
        };
        
        for (var i = 0; i < handlers.Count - 1; i++)
        {
            handlers[i].SetNext(handlers[i + 1]);
        }
        
        Console.WriteLine("Welcome to Customer Support");
        
        var resolved = handlers.Count == 0;
        while (!resolved)
        {
            resolved = handlers[0].Handle();
            if (!resolved)
            {
                Console.WriteLine("Sorry, we couldn't determine the right support level for you. Let's try again.");
            }
        }
    }
}