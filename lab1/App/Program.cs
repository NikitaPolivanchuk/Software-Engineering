using App.DependencyInjection;
using App.Entities;
using App.Providers;
using App.Services;
using App.ValueObjects;
using App.ValueObjects.Currencies;
using Microsoft.Extensions.DependencyInjection;

namespace App;

public abstract class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddCurrency();
        services.AddSingleton<IWarehouseProvider, InMemoryWarehouseProvider>(_ =>
        {
            var provider = new InMemoryWarehouseProvider();
            provider.AddWarehouses(GetWarehousesMock());
            return provider;
        });
        services.AddSingleton<WarehouseReportService>();
        
        var provider = services.BuildServiceProvider();
        
        var service = provider.GetRequiredService<WarehouseReportService>();

        Console.WriteLine(service.GenerateReport());
    }

    public static List<Warehouse> GetWarehousesMock()
    {
        var electronicsCategory = new Category("Electronics", "Devices such as smartphones, laptops, and other electronic gadgets.");
        var smartphonePrice = new Usd(999, 99);
        var smartphone = new Product("Smartphone", "A high-end smartphone with a 6.7-inch OLED display, 128GB storage, and a powerful camera setup.", smartphonePrice, electronicsCategory, 50);
        
        var apparelCategory = new Category("Apparel", "Clothing and accessories such as jackets, pants, shirts, etc.");
        var jacketPrice = new Eur(199, 50);
        var leatherJacket = new Product("Leather Jacket", "A stylish black leather jacket made from premium cowhide leather, perfect for colder weather.", jacketPrice, apparelCategory, 30);
        
        var homeAppliancesCategory = new Category("Home Appliances", "Appliances for the home, such as coffee machines, fridges, and vacuums.");
        var coffeeMachinePrice = new Uah(3999, 99);
        var coffeeMachine = new Product("Coffee Machine", "A high-quality coffee machine with an integrated grinder, perfect for brewing espresso and other coffee drinks.", coffeeMachinePrice, homeAppliancesCategory, 10);

        
        var address1 = new Address(
            "123 Elm St", 
            "Springfield", 
            "IL", 
            "62701", 
            "USA"
        );
        var warehouse1 = new Warehouse(address1);
        warehouse1.Products.Add(smartphone);
        warehouse1.Products.Add(leatherJacket);
        
        var address2 = new Address(
            "456 Oak Ave", 
            "Madison", 
            "WI", 
            "53703", 
            "USA"
        );
        var warehouse2 = new Warehouse(address2);
        warehouse2.Products.Add(coffeeMachine);
        
        return [warehouse1, warehouse2];
    }
}