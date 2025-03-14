namespace AbstractFactory.Domain.Smartwatches;

public class SamsungSmartwatch : Smartwatch
{
    public int BatteryLife { get; }

    public SamsungSmartwatch(string model, int batteryLife) : base(model)
    {
        BatteryLife = batteryLife;
    }

    public override void DisplaySpecifications()
    {
        Console.WriteLine($"Samsung Smartwatch - Model: {Model}, Battery Life: {BatteryLife} hours");
    }
}