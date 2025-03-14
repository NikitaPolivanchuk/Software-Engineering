using AbstractFactory.Factories;

namespace AbstractFactory;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        var gadget = 0;
        var brand = 0;
        
        Console.WriteLine("What do you want to buy?");
        Console.WriteLine("1 - Laptop");
        Console.WriteLine("2 - Smartphone");
        Console.WriteLine("3 - Smartwatch");
        while (gadget is < 1 or > 3)
        {
            Console.Write("> ");
            int.TryParse(Console.ReadLine(), out gadget);
        }

        Console.WriteLine("Which brand would you like to buy?");
        Console.WriteLine("1 - Dell");
        Console.WriteLine("2 - Huawei");
        Console.WriteLine("3 - Samsung");
        while (brand is < 1 or > 3)
        {
            Console.Write("> ");
            int.TryParse(Console.ReadLine(), out brand);
        }

        IDeviceFactory factory = brand switch
        {
            1 => new DellFactory(),
            2 => new HuaweiFactory(),
            3 => new SamsungFactory(),
            _ => throw new ArgumentOutOfRangeException()
        };

        Console.WriteLine("You bought:");
        switch (gadget)
        {
            case 1:
                factory.CreateLaptop().DisplaySpecifications();
                break;
            case 2:
                factory.CreateSmartphone().DisplaySpecifications();
                break;
            case 3:
                factory.CreateSmartwatch().DisplaySpecifications();
                break;
        }
    }
}