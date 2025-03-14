using AbstractFactory.Domain.Laptops;
using AbstractFactory.Domain.Smartphones;
using AbstractFactory.Domain.Smartwatches;

namespace AbstractFactory.Factories;

public class HuaweiFactory : IDeviceFactory
{
    public Laptop CreateLaptop()
    {
        return new HuaweiLaptop("MateBook X Pro", "OLED");
    }

    public Smartphone CreateSmartphone()
    {
        return new HuaweiSmartphone("P40 Pro", "108MP");
    }

    public Smartwatch CreateSmartwatch()
    {
        return new HuaweiSmartwatch("Watch GT 3", "Fluoroelastomer");
    }
}