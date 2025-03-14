using Builder.Builders;

namespace Builder.Domain;

public class Hero : Character
{
    public List<string> GoodDeeds { get; } = [];

    protected Hero() {}

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Good Deeds:");
        foreach (var deed in GoodDeeds)
        {
            Console.WriteLine($"- {deed}");
        }
    }

    public void MakeGoodDeed()
    {
        Console.WriteLine("Making a good deed...");
    }

    public static HeroBuilder CreateBuilder()
    {
        return new HeroBuilder(new Hero());
    }
}