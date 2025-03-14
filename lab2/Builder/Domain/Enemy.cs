using Builder.Builders;

namespace Builder.Domain;

public class Enemy : Character
{
    public List<string> BadDeeds { get; } = [];

    protected Enemy() {}

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Bad Deeds:");
        foreach (var deed in BadDeeds)
        {
            Console.WriteLine($"- {deed}");
        }
    }

    public void MakeBadDeed()
    {
        Console.WriteLine("Making a bad deed...");
    }

    public static EnemyBuilder CreateBuilder()
    {
        return new EnemyBuilder(new Enemy());
    }
}