namespace AbstractFactory.Domain.Smartwatches;

public class HuaweiSmartwatch : Smartwatch
{
    public string StrapMaterial { get; }

    public HuaweiSmartwatch(string model, string strapMaterial) : base(model)
    {
        StrapMaterial = strapMaterial;
    }

    public override void DisplaySpecifications()
    {
        Console.WriteLine($"Huawei Smartwatch - Model: {Model}, Strap Material: {StrapMaterial}");
    }
}