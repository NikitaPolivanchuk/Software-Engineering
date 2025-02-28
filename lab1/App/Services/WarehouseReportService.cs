using System.Text;
using App.Entities;
using App.Providers;
using App.ValueObjects.Currencies;
using Finance.Services;

namespace App.Services;

public class WarehouseReportService
{
    private readonly List<Warehouse> _warehouses;
    private readonly CurrencyConverter _currencyConverter;

    public WarehouseReportService(IWarehouseProvider warehouseProvider, CurrencyConverter currencyConverter)
    {
        _warehouses = warehouseProvider.GetWarehouses();
        _currencyConverter = currencyConverter;
    }
    
    public string GenerateReport()
    {
        var report = new StringBuilder();
        
        report.AppendLine("Warehouse Report");
        report.AppendLine("--------------------------------------------------");

        decimal grandTotalInventoryValue = 0;

        foreach (var warehouse in _warehouses)
        {
            AppendWarehouseDetails(report, warehouse);

            var warehouseTotalInventoryValue = CalculateWarehouseInventoryValue(warehouse);

            report.AppendLine("--------------------------------------------------");
            report.AppendLine($"Total Inventory Value for this Warehouse: {warehouseTotalInventoryValue:C}");
            report.AppendLine("--------------------------------------------------");

            grandTotalInventoryValue += warehouseTotalInventoryValue;
        }

        AppendGrandTotal(report, grandTotalInventoryValue);

        return report.ToString();
    }

    private void AppendWarehouseDetails(StringBuilder report, Warehouse warehouse)
    {
        report.AppendLine($"Warehouse Location: {warehouse.Location}");
        report.AppendLine("--------------------------------------------------");

        if (warehouse.Products.Count == 0)
        {
            report.AppendLine("No products in warehouse.");
        }
        else
        {
            report.AppendLine("Products:");
            foreach (var product in warehouse.Products)
            {
                report.AppendLine(product.ToString());
            }
        }
    }

    private decimal CalculateWarehouseInventoryValue(Warehouse warehouse)
    {
        return warehouse.Products.Sum(product =>
        {
            var generalPrice = _currencyConverter.Convert<Usd>(product.Price);
            return generalPrice.ToDecimal() * product.Quantity;
        });
    }

    private void AppendGrandTotal(StringBuilder report, decimal grandTotalInventoryValue)
    {
        report.AppendLine("--------------------------------------------------");
        report.AppendLine($"Grand Total Inventory Value for All Warehouses: {grandTotalInventoryValue:C}");
        report.AppendLine("--------------------------------------------------");
    }

}