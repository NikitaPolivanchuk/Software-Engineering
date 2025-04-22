namespace ChainOfResponsibility;

public class SupervisorSupportHandler : SupportHandler
{
    public override bool Handle()
    {
        Console.Write("Supervisor: Would you like to speak to a supervisor? (yes/no): ");
        var input = Console.ReadLine()?.Trim().ToLower();
        if (input == "yes")
        {
            Console.WriteLine("You are now connected to the Support Supervisor");
            return true;
        }
        return base.Handle();
    }
}