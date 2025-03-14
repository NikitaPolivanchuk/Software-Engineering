using AbstractFactory.Domain.Laptops;
using AbstractFactory.Domain.Smartphones;
using AbstractFactory.Domain.Smartwatches;

namespace AbstractFactory.Factories;

public interface IDeviceFactory
{
    Laptop CreateLaptop();
    Smartphone CreateSmartphone();
    Smartwatch CreateSmartwatch();
}