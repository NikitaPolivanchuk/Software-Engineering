using App.ValueObjects;

namespace App.Entities;

public class Warehouse
{
    public Address Location { get; set; }
    public List<Product> Products { get; set; }

    public Warehouse(Address location)
    {
        Location = location;
        Products = [];
    }
}