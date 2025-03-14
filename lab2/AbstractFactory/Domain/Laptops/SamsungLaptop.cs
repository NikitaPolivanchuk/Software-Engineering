namespace AbstractFactory.Domain.Laptops;

public class SamsungLaptop : Laptop
{
    public int Ram { get; }

    public SamsungLaptop(string model, int ram) : base(model)
    {
        Ram = ram;
    }

    public override void DisplaySpecifications()
    {
        Console.WriteLine($"Samsung Laptop - Model: {Model}, RAM: {Ram} GB");
    }
}