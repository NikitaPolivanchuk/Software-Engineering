namespace Prototype;

public class Virus
{
    public string Name { get; }
    public int Age { get; }
    public double Weight { get; }
    public string Species { get; }
    public List<Virus> Children { get; }
    
    public Virus(string name, int age, double weight, string species)
    {
        Name = name;
        Age = age;
        Weight = weight;
        Species = species;
        Children = [];
    }
    
    public Virus Clone()
    {
        var clone = new Virus(Name, Age, Weight, Species);
        foreach (var child in Children)
        {
            clone.Children.Add(child.Clone());
        }
        return clone;
    }
    
    public void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Weight: {Weight}, Species: {Species}");
        foreach (var child in Children)
        {
            child.PrintInfo();
        }
    }
}