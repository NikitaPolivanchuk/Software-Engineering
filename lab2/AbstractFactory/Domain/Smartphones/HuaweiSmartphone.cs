namespace AbstractFactory.Domain.Smartphones;

public class HuaweiSmartphone : Smartphone
{
    public string CameraResolution { get; set; }

    public HuaweiSmartphone(string model, string cameraResolution) : base(model)
    {
        CameraResolution = cameraResolution;
    }

    public override void DisplaySpecifications()
    {
        Console.WriteLine($"Huawei Smartphone - Model: {Model}, Camera Resolution: {CameraResolution}");
    }
}