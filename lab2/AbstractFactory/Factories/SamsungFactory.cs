using AbstractFactory.Domain.Laptops;
using AbstractFactory.Domain.Smartphones;
using AbstractFactory.Domain.Smartwatches;

namespace AbstractFactory.Factories;

public class SamsungFactory : IDeviceFactory
{
    public Laptop CreateLaptop()
    {
        return new SamsungLaptop("Galaxy Book", 16);
    }

    public Smartphone CreateSmartphone()
    {
        return new SamsungSmartphone("Galaxy S24", true);
    }

    public Smartwatch CreateSmartwatch()
    {
        return new SamsungSmartwatch("Galaxy Watch 4", 48);
    }
}