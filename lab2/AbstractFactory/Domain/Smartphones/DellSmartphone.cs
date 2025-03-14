namespace AbstractFactory.Domain.Smartphones;

public class DellSmartphone : Smartphone
{
    public int BatteryCapacity { get; }

    public DellSmartphone(string model, int batteryCapacity) : base(model)
    {
        BatteryCapacity = batteryCapacity;
    }

    public override void DisplaySpecifications()
    {
        Console.WriteLine($"Dell Smartphone - Model: {Model}, Battery Capacity: {BatteryCapacity} mAh");
    }
}