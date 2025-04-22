namespace ChainOfResponsibility;

public class TechnicalSupportHandler : SupportHandler
{
    public override bool Handle()
    {
        Console.Write("Technical Support: Is your issue related to a technical problem? (yes/no): ");
        var input = Console.ReadLine()?.Trim().ToLower();
        if (input == "yes")
        {
            Console.WriteLine("You are now connected to Technical Support");
            return true;
        }
        return base.Handle();
    }
}