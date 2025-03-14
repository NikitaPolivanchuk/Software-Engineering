namespace AbstractFactory.Domain.Laptops;

public abstract class Laptop
{
    public string Model { get; }

    protected Laptop(string model)
    {
        Model = model;
    }

    public abstract void DisplaySpecifications();
}