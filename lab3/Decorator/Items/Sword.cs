using Decorator.Heroes;

namespace Decorator.Items;

public class Sword : HeroDecorator
{
    public Sword(IHero hero) : base(hero) { }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine("Equipped: Sword");
    }
}