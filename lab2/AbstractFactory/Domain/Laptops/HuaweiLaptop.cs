namespace AbstractFactory.Domain.Laptops;

public class HuaweiLaptop : Laptop
{
    public string DisplayType { get; }

    public HuaweiLaptop(string model, string displayType) : base(model)
    {
        DisplayType = displayType;
    }

    public override void DisplaySpecifications()
    {
        Console.WriteLine($"Huawei Laptop - Model: {Model}, Display: {DisplayType}");
    }
}