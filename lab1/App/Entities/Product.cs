using Finance.Models;

namespace App.Entities;

public class Product
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Currency Price { get; set; }
    public Category Category { get; set; }
    public int Quantity { get; set; }

    public Product(string name, string description, Currency price, Category category, int quantity)
    {
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{Name} - Quantity: {Quantity}, Price: {Price}, Category: {Category.Name}";
    }
}