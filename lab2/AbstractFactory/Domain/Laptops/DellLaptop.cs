namespace AbstractFactory.Domain.Laptops;

public class DellLaptop : Laptop
{
    public string Processor { get; }

    public DellLaptop(string model, string processor) : base(model)
    {
        Processor = processor;
    }

    public override void DisplaySpecifications()
    {
        Console.WriteLine($"Dell Laptop - Model: {Model}, Processor: {Processor}");
    }
}