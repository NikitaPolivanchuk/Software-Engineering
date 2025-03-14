using FactoryMethod.Factories;

namespace FactoryMethod;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Where do you want to create subscription?");
        Console.WriteLine("Choose one of the following options:");
        Console.WriteLine("1 - Web site");
        Console.WriteLine("2 - Mobile app");
        Console.WriteLine("3 - Call manager");

        while (true)
        {
            Console.Write("> ");
            if (!int.TryParse(Console.ReadLine(), out var input))
            {
                continue;
            }
            var factory = GetSubscriptionFactory(input);
            if (factory == null)
            {
                continue;
            }
            var subscription = factory.CreateSubscription();
            Console.WriteLine("Created subscription:");
            Console.WriteLine(subscription);
            break;
        }
    }

    private static SubscriptionFactory? GetSubscriptionFactory(int app)
    {
        return app switch
        {
            1 => new WebSite(),
            2 => new MobileApp(),
            3 => new ManagerCall(),
            _ => null,
        };
    }
}