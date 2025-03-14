namespace AbstractFactory.Domain.Smartwatches;

public abstract class Smartwatch
{
    public string Model { get; }

    protected Smartwatch(string model)
    {
        Model = model;
    }

    public abstract void DisplaySpecifications();
}