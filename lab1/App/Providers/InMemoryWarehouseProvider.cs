using App.Entities;

namespace App.Providers;

public class InMemoryWarehouseProvider : IWarehouseProvider
{
    private readonly List<Warehouse> _warehouses = [];

    public void AddWarehouses(IEnumerable<Warehouse> warehouses)
    {
        _warehouses.AddRange(warehouses);
    }
    
    public List<Warehouse> GetWarehouses()
    {
        return _warehouses;
    }
}