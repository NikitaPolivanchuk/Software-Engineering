namespace AbstractFactory.Domain.Smartphones;

public class SamsungSmartphone : Smartphone
{
    public bool Has5G { get; }

    public SamsungSmartphone(string model, bool has5G) : base(model)
    {
        Has5G = has5G;
    }

    public override void DisplaySpecifications()
    {
        Console.WriteLine($"Samsung Smartphone - Model: {Model}, Has 5G: {Has5G}");
    }
}