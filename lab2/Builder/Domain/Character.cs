using System.Drawing;

namespace Builder.Domain;

public abstract class Character
{
    public string Name { get; set; } = string.Empty;
    public double Height { get; set; }
    public string Build { get; set; } = string.Empty;
    public Color HairColor { get; set; } = Color.Empty;
    public Color EyeColor { get; set; } = Color.Empty;
    public List<string> Inventory { get; } = [];
    
    protected Character() {}
    
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Height: {Height} meters");
        Console.WriteLine($"Build: {Build}");
        Console.WriteLine($"Hair Color: {HairColor.Name}");
        Console.WriteLine($"Eye Color: {EyeColor.Name}");
        Console.WriteLine("Inventory: ");
        foreach (var item in Inventory)
        {
            Console.WriteLine($"- {item}");
        }
    }
}