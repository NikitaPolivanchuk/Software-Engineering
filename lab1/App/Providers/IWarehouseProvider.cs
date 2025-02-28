using App.Entities;

namespace App.Providers;

public interface IWarehouseProvider
{
    List<Warehouse> GetWarehouses();
}