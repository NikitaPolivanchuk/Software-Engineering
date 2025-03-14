using AbstractFactory.Domain.Laptops;
using AbstractFactory.Domain.Smartphones;
using AbstractFactory.Domain.Smartwatches;

namespace AbstractFactory.Factories;

public class DellFactory : IDeviceFactory
{
    public Laptop CreateLaptop()
    {
        return new DellLaptop("XPS 13", "Intel Core i7");
    }

    public Smartphone CreateSmartphone()
    {
        return new DellSmartphone("Vostro 5510", 4000);
    }

    public Smartwatch CreateSmartwatch()
    {
        return new DellSmartwatch("STW 1", true);
    }
}