namespace AbstractFactory.Domain.Smartphones;

public abstract class Smartphone
{
    public string Model { get; }

    protected Smartphone(string model)
    {
        Model = model;
    }

    public abstract void DisplaySpecifications();
}