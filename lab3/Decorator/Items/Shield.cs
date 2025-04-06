using Decorator.Heroes;

namespace Decorator.Items;

public class Shield : HeroDecorator
{
    public Shield(IHero hero) : base(hero) { }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine("Equipped: Shield");
    }
}