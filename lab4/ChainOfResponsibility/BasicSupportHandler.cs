namespace ChainOfResponsibility;

public class BasicSupportHandler : SupportHandler
{
    public override bool Handle()
    {
        Console.Write("Basic Support: Do you have a general question? (yes/no): ");
        var input = Console.ReadLine()?.Trim().ToLower();
        if (input == "yes")
        {
            Console.WriteLine("You are now connected to Basic Support");
            return true;
        }
        return base.Handle();
    }
}