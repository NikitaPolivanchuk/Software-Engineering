namespace AbstractFactory.Domain.Smartwatches;

public class DellSmartwatch : Smartwatch
{
    public bool HasGPS { get; }

    public DellSmartwatch(string model, bool hasGps) : base(model)
    {
        HasGPS = hasGps;
    }

    public override void DisplaySpecifications()
    {
        Console.WriteLine($"Dell Smartwatch - Model: {Model}, GPS: {HasGPS}");
    }
}