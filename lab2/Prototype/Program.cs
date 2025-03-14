namespace Prototype;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        var fatherVirus = new Virus("FatherVirus", 5, 1.2, "VirusSpeciesA");
        
        var child1 = new Virus("ChildVirus1", 3, 0.8, "VirusSpeciesB");
        var child2 = new Virus("ChildVirus2", 2, 0.5, "VirusSpeciesC");
        
        fatherVirus.Children.Add(child1);
        fatherVirus.Children.Add(child2);
        
        var grandChild1 = new Virus("GrandChildVirus1", 1, 0.3, "VirusSpeciesD");
        var grandChild2 = new Virus("GrandChildVirus2", 1, 0.4, "VirusSpeciesE");
        
        child1.Children.Add(grandChild1);
        child2.Children.Add(grandChild2);
        
        Console.WriteLine("Original Virus Family:");
        fatherVirus.PrintInfo();
        
        var clonedVirus = fatherVirus.Clone();
        
        Console.WriteLine("\nCloned Virus Family:");
        clonedVirus.PrintInfo();
    }
}