namespace ChainOfResponsibility;

public class BillingSupportHandler : SupportHandler
{
    public override bool Handle()
    {
        Console.Write("Billing Support: Do you have a question about payments or billing? (yes/no): ");
        var input = Console.ReadLine()?.Trim().ToLower();
        if (input == "yes")
        {
            Console.WriteLine("You are now connected to Billing Support");
            return true;
        }
        return base.Handle();
    }
}